using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiManager : MonoBehaviour
{

    public Rigidbody2D rb;

    [SerializeField] float speed = 15f;

    private void Start()
    {
        rb.velocity = this.transform.up * speed;
        MeteorManager meteorManager = new MeteorManager();

        Invoke("Destroy", 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteor"))
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

}
