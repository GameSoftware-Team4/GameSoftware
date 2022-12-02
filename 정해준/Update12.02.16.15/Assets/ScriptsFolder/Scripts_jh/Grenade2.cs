using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Grenade2 : MonoBehaviour
{
    public Rigidbody rigid;
    bool eff_start = false;

    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        StartCoroutine(Explosion());
        eff_start = false;
    }

    // Update is called once per frame
    void Update()
    {
        Eff(transform);
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
        if(eff_start)
        {
            var e1 = PhotonNetwork.Instantiate(Path.Combine("Prefabs_jhj", "gre_epx"), t.position, gameObject.transform.rotation);
            var e2 = PhotonNetwork.Instantiate(Path.Combine("Prefabs_jhj", "poison_smoke"), t.position, gameObject.transform.rotation);
            var e3 = PhotonNetwork.Instantiate(Path.Combine("Prefabs_jhj", "gre_fire"), t.position, gameObject.transform.rotation);
            Destroy(e1, 10f);
            Destroy(e2, 10f);
            Destroy(e3, 10f);
        }
        eff_start = false;

    }
}


