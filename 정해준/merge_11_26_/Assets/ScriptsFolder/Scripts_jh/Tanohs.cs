using UnityEngine;
using System.Collections;

public class Tanohs : MonoBehaviour
{
    public float t_damage_jhj = 100f;
    public float radius = 100f;
    public GameObject eff;
    public GameObject player_jhj;

    // Start is called before the first frame update
    IEnumerator T_attatck()
    {
        yield return new WaitForSeconds(10f);
        Collider[] hitColliders_jhj = Physics.OverlapSphere(player_jhj.transform.position, radius); // 지정한 구안에 있는 오브젝트를 검거
        int i = 0;

        while (i < hitColliders_jhj.Length)
        {

            if (hitColliders_jhj[i].tag == "Monster") // 몬스터들만을 검거
            {

                Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                m.OngreDamage(t_damage_jhj);

                Debug.Log("강력한 공격!" + t_damage_jhj + "데미지!!");
            }
            i++;

        }



    }
    void Start()
    {
        eff = Resources.Load<GameObject>("T_skill");
        player_jhj = GameObject.Find("Player");
        T_attatck();
        GameObject g = Instantiate(eff, player_jhj.transform);
        StartCoroutine(T_attatck());
        Destroy(g, 20f);
    }

}



