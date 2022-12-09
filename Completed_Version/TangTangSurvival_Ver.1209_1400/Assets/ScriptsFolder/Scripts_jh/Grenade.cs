using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public Rigidbody rigid;
    bool eff_start = false;

    void Start()
    {

        rigid = GetComponent<Rigidbody>();
        StartCoroutine(Explosion());
    }

    // Update is called once per frame
    void Update()
    {
        Eff(transform);
        eff_start = false;
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(3f);
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        eff_start = true;


    }
    void Eff(Transform t)
    {
        if (eff_start)
        {
            GameObject e1 = PhotonNetwork.Instantiate(Path.Combine("Prefabs_jhj", "gre_epx"), t.position, gameObject.transform.rotation);
            GameObject e2 = PhotonNetwork.Instantiate(Path.Combine("Prefabs_jhj","poison_smoke"), t.position, gameObject.transform.rotation);
            Destroy(e1, 5f);
            Destroy(e2, 5f);

        }
        eff_start = false;

    }
}


