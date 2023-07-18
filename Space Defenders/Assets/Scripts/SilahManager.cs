using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class SilahManager : MonoBehaviour
{
    public GameObject mermiPrefab;
    private Rigidbody2D rb;

    public Transform firePoint;
    public GameObject mermi;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FollowMouse();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
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
