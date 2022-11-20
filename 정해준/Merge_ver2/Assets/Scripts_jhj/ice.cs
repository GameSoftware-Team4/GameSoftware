using UnityEngine;
using System.Collections;

public class ice : MonoBehaviour
{
    float ice_damage_jhj = 20;
    public GameObject iceEffect_jhj;
    GameObject player_jhj;
    public float ep_radius = 20f;
    public float delay = 0;
    void IceDamage(Vector3 center, float radius)
    {
        Instantiate(iceEffect_jhj, player_jhj.transform);
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            //target_jhj = hitColliders_jhj[i].gameObject.GetComponent<Mob_jhj>(); //Ÿ�ٵ��� ���͸� ����ϴ��� �˰�
            if(hitColliders_jhj[i].tag == "Monster") // ���͵鸸�� �˰�
            {

                Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                m.OnIceDamaged(ice_damage_jhj,delay);

                Debug.Log("����!! " + ice_damage_jhj + "������!!");
            }
            i++;

        }
        
    }


   void Start()
    {
        player_jhj = GameObject.Find("Player");
        IceDamage(player_jhj.transform.position, ep_radius);

    }
}

