using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 9f;
    private Rigidbody bulletRig;
    // Start is called before the first frame update
    void Start()
    {
        // bulletRig = GetComponent<Rigidbody>();
        // bulletRig.velocity = Vector3.forward * speed;

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
