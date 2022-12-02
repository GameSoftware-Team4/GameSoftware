using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript_pwj : MonoBehaviour
{
    public Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 dir = Vector3.forward;
        rig.AddForce(dir * 5, ForceMode.Impulse);*/
        // bullet.GetComponent<Rigidbody>().AddForce(shotPos.forward * 5, ForceMode.Impulse);
    }
}
