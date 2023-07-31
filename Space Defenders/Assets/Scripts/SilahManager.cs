using UnityEngine;

public class SilahManager : MonoBehaviour
{
    public GameObject mermiPrefab;
    private Rigidbody2D rb;

    public Transform firePoint;
    public GameObject mermi;

    SkorManager skorManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FollowMouse();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));

            Instantiate(mermiPrefab, firePoint.position, firePoint.rotation);

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
