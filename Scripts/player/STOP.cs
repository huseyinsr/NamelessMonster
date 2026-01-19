using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class STOP : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioSource auidosource;
    public AudioClip Yozgat;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // DÜZELTME: Rigidbody2D alýnmalý
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                if (playerRb != null) { playerRb.constraints = RigidbodyConstraints2D.FreezeAll; }

                StartCoroutine(BekleVeCoz(playerRb));
                auidosource.PlayOneShot(Yozgat);
            }        
        }
    }

    IEnumerator BekleVeCoz(Rigidbody2D playerRb)
    {
        Debug.Log("3 saniye bekleniyor...");
        yield return new WaitForSeconds(3f);

        // Serbest býrak
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.freezeRotation = true; // sadece dönmeyi sabitle
        }

        if (playerRb != null)
        {
            playerRb.constraints = RigidbodyConstraints2D.None;
            playerRb.freezeRotation = true; // player dönmesin
        }
        

    }
}
