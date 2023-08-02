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
        if (skorManager.skor >= 30 && skorManager.skor < 50)
        {
            fireRate = 0.3f;
        }
        else if (skorManager.skor >= 50 && skorManager.skor < 90)
        {
            fireRate = 0.1f;
        }
        else if (skorManager.skor >= 100)
        {
            fireRate = 0f;
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
