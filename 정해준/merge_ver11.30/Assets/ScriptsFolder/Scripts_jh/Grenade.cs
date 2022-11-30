using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject meshObj;
    public GameObject effectObj;
    public GameObject effectObj_2;

    public Rigidbody rigid;
    bool eff_start = false;

    void Start()
    {

        rigid = GetComponent<Rigidbody>();
        StartCoroutine(Explosion());
        meshObj = Resources.Load<GameObject>("prefabs_jhj/gre_mesh");
        effectObj = Resources.Load<GameObject>("prefabs_jhj/gre_epx");
        effectObj_2 = Resources.Load<GameObject>("prefabs_jhj/poison_smoke");
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
        meshObj.SetActive(false);
        effectObj.SetActive(true);
        eff_start = true;


    }
    void Eff(Transform t)
    {
        if (eff_start)
        {
            var e1 = Instantiate(effectObj_2, t.position, effectObj_2.transform.rotation);

            Destroy(e1, 5f);

        }
        eff_start = false;

    }
}


