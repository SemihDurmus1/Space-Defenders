using UnityEngine;
using UnityEngine.UI;


public class MeteorManager : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;

    SkorManager skorManager;
    CanManager canManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject skorObjesi = GameObject.FindWithTag("Skor");
        skorManager = skorObjesi.GetComponent<SkorManager>();

        GameObject canObjesi = GameObject.FindWithTag("Can");
        canManager = canObjesi.GetComponent<CanManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mermi"))
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("Carpti", true);

            Invoke("DestroyMeteor", 0.3f);
            Invoke("SkorVer", 0.3f);
        }
        else if (collision.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("Carpti", true);

            Invoke("DestroyMeteor", 0.3f);
            Invoke("HasarVer", 0.3f);
        }
    }

    private void HasarVer()
    {
        canManager.can -= Random.Range(5, 15);
    }

    private void SkorVer()
    {
        skorManager.skor += 1f;
    }

    public void DestroyMeteor()
    {
        Destroy(gameObject);
    }
}
