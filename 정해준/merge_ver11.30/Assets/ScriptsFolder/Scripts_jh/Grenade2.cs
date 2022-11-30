using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade2 : MonoBehaviour
{
    public GameObject meshObj;
    public GameObject effectObj;
    public GameObject effectObj_2;
    public GameObject effectObj_3;
    public Rigidbody rigid;
    bool eff_start = false;

    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        StartCoroutine(Explosion());
        meshObj = Resources.Load<GameObject>("prefabs_jhj/gre_mesh");
        effectObj = Resources.Load<GameObject>("prefabs_jhj/gre_epx");
        effectObj_2 = Resources.Load<GameObject>("prefabs_jhj/poison_smoke");
        effectObj_3 = Resources.Load<GameObject>("prefabs_jhj/gre_fire");
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
        eff_start = true;
        effectObj.SetActive(true);

    }
    void Eff(Transform t)
    {
        if(eff_start)
        {
            var e1 = Instantiate(effectObj_2, t.position, effectObj_2.transform.rotation);
            var e2 = Instantiate(effectObj_3, t.position, effectObj_3.transform.rotation);
            Destroy(e1, 10f);
            Destroy(e2, 10f);
        }
        eff_start = false;

    }
}


