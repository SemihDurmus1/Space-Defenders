using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeteorManager : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;


  
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("çarptý");
        if (collision.name == "Kale")
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("Carpti", true);

            Invoke("DestroyMeteor", 0.3f);

        }
    }

    public void DestroyMeteor()
    {
        Destroy(gameObject);
    }
}
