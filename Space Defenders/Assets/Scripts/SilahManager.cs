using UnityEngine;

public class SilahManager : MonoBehaviour
{
    [SerializeField] GameObject mermiPrefab;
    private Rigidbody2D rb;

    [SerializeField] Transform firePoint;
    [SerializeField] Transform joystick;

    SkorManager skorManager;

    private Vector3 initialPosition;

    private float fireRate = 0.7f; 
    private float nextFireTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject skorObjesi = GameObject.FindWithTag("Skor");
        skorManager = skorObjesi.GetComponent<SkorManager>();

        initialPosition = joystick.position;
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
                nextFireTime = Time.time + fireRate; // Bir sonraki mermi spawn zamanýný güncelle
            }
        }
        BoostFireRate();

    }

    private void BoostFireRate()
    {
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
        Vector3 offset = joystick.position - initialPosition;

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        //Aþaðýdaki kod, silahýn ekrana dokunulan yere dönmesini saðlýyor
        //Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = rotation;
    }
}
