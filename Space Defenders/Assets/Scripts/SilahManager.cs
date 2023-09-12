using UnityEngine;

public class SilahManager : MonoBehaviour
{
    public GameObject mermiPrefab;
    private Rigidbody2D rb;

    public Transform firePoint;

    SkorManager skorManager;

    public float fireRate = 0.7f; // Her mermi spawn aras�nda ge�mesi gereken s�re (sn)
    private float nextFireTime = 0f; // Bir sonraki mermi spawn zaman�

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject skorObjesi = GameObject.FindWithTag("Skor");
        skorManager = skorObjesi.GetComponent<SkorManager>();
    }

    private void Update()
    {
        FollowMouse();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Time.time >= nextFireTime)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                Instantiate(mermiPrefab, firePoint.position, firePoint.rotation);
                nextFireTime = Time.time + fireRate; // Bir sonraki mermi spawn zaman�n� g�ncelle
            }
        }
        if (skorManager.skor >= 10 && skorManager.skor < 20)
        {
            fireRate = 0.6f;
        }
        else if (skorManager.skor >= 20 && skorManager.skor < 30)
        {
            fireRate = 0.5f;
        }
        else if (skorManager.skor >= 30 && skorManager.skor < 40)
        {
            fireRate = 0.4f;
        }
        else if (skorManager.skor >= 40 && skorManager.skor < 50)
        {
            fireRate = 0.3f;
        }
        else if (skorManager.skor >= 50 && skorManager.skor < 70)
        {
            fireRate = 0.2f;
        }
        else if (skorManager.skor >= 70 && skorManager.skor < 100)
        {
            fireRate = 0.1f;
        }
        else if (skorManager.skor >= 100 && skorManager.skor < 110)
        {
            fireRate = 0.09f;
        }
        else if (skorManager.skor >= 110 && skorManager.skor < 120)
        {
            fireRate = 0.08f;
        }
        else if (skorManager.skor >= 120 && skorManager.skor < 130)
        {
            fireRate = 0.07f;
        }
        else if (skorManager.skor >= 130 && skorManager.skor < 140)
        {
            fireRate = 0.06f;
        }
        else if (skorManager.skor >= 140 && skorManager.skor < 150)
        {
            fireRate = 0.05f;
        }
        else if (skorManager.skor >= 150 && skorManager.skor < 160)
        {
            fireRate = 0.04f;
        }
        else if (skorManager.skor >= 160 && skorManager.skor < 170)
        {
            fireRate = 0.03f;
        }
        else if (skorManager.skor >= 170 && skorManager.skor < 180)
        {
            fireRate = 0.02f;
        }
        else if (skorManager.skor > 200)
        {
            fireRate = 0.01f;
        }

    }

    void FollowMouse()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
