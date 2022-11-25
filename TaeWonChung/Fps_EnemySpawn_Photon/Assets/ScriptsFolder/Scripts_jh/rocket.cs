using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour
{
    float r_damage_jhj = 50;
    Mob target_jhj;
    public float radius = 1f;
    void Start( ) 
    {
        Collider[] hitColliders_jhj = Physics.OverlapSphere(transform.position, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
        int i = 0;
            while (i<hitColliders_jhj.Length)
            {

                if (hitColliders_jhj[i].tag == "Monster") // ���͵鸸�� �˰�
                {

                    Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                    m.OnrocketDamage(r_damage_jhj);

                    Debug.Log("����" + r_damage_jhj + "������!!");
                }
                i++;

            }

        
    }
    
}

