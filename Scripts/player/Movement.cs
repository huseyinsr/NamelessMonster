using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float walkspeed = 50f;
    public float runSpeed = 75f;
    private Rigidbody2D rb;
    private Vector2 movement;
    Animator animator;
    Animation animationWalk;
    Animation animationIdle;
    private float moveX;

    void Start()
    {
        animator = GetComponent<Animator>();
        animationWalk = GetComponent<Animation>();
        
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // stop rotating
    }

    void Update()
    {
        // Inputlar� al
        movement.x = Input.GetAxisRaw("Horizontal"); // with A-D keys or left right arrows you can move on x axis
        movement.y = Input.GetAxisRaw("Vertical");   // W-S keys or up down arrows you can move on y axis

        // with this code you can change the way you are looking
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-14f, 14f, 14f); //looks left
            rb.linearVelocity = new Vector2(50f, rb.linearVelocity.y);

        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(14f, 14f, 14f); // looks right
            
            rb.linearVelocity = new Vector2(50f, rb.linearVelocity.y);
        }
        // Shift basılıysa koş
        if (Input.GetKey(KeyCode.LeftShift))
        { speed = runSpeed; }
        else {  speed = walkspeed; }

            rb.linearVelocity = movement.normalized * speed;
    }
   

}








































































































//made by ata sekercioglu