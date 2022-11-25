using UnityEngine;
using System.Collections;

public class Tanohs : MonoBehaviour
{
    public float t_damage_jhj = 100f;
    public float radius = 100f;
    public GameObject eff;

    // Start is called before the first frame update
    void Start()
    {
        Collider[] hitColliders_jhj = Physics.OverlapSphere(transform.position, radius); // 지정한 구안에 있는 오브젝트를 검거
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            if (hitColliders_jhj[i].tag == "Monster") // 몬스터들만을 검거
            {
                GameObject g = Instantiate(eff, hitColliders_jhj[i].transform);
                Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                m.OngreDamage(t_damage_jhj);
                Destroy(g, 4f);
                Debug.Log("강력한 공격!" + t_damage_jhj + "데미지!!");
            }
            i++;

        }


    }

    // Update is called once per frame
    void Update()
    {

    }

}



