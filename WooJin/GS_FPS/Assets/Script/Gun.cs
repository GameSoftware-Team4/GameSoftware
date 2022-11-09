using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody Bullet;
    public AudioClip GunShot;
    public float bulletSpeed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("hello");
            Rigidbody rb = Instantiate(Bullet, transform.position, transform.rotation);
            rb.velocity = transform.TransformDirection(new Vector3(0, 0, -bulletSpeed));

        }
    }
}
