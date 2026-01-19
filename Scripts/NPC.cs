using System.Collections;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public AudioClip Ses;
    public Transform[] waypoints;
    public float speed = 20f;
    private int currentWaypointIndex = 0;
    private bool isWaiting = false;
    private SpriteRenderer spriteRenderer;
    public Sprite yeniGoruntu;
    private AudioSource audiosource;
    private Rigidbody2D rb;
    public Sprite yeniGoruntu2;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        audiosource.PlayOneShot(Ses);
        if (waypoints.Length == 0 || isWaiting) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector2 direction = (target.position - transform.position).normalized;

        // ?n?nde Player var m? diye kontrol et (Raycast)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            // NPC Player?? g?r?nce durur
            rb.linearVelocity = Vector2.zero;
            //return;

            // E?er yan?ndan dolans?n istersen yukar?daki return'u silip ?u sat?r? a?:
             direction = new Vector2(-direction.y, direction.x);
        }

        // Normal hareket
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        // Waypoint?e ula?t? m??
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitBeforeNextMove(6f));
        }
        if (target.position.x < transform.position.x) 
        {
            transform.localScale = new Vector3(-14f, 14f, 14f);
        }
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(14f, 14f, 14f);
        }
    }

    IEnumerator WaitBeforeNextMove(float waitTime)
    {
        isWaiting = true;
        spriteRenderer.sprite = yeniGoruntu;
        audiosource.PlayOneShot(Ses);
        yield return new WaitForSeconds(waitTime);
        spriteRenderer.sprite = yeniGoruntu2;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        isWaiting = false;
    }
}
