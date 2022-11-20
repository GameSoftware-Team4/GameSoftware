using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_damage : MonoBehaviour
{
    
 
    
    float p_damage_jhj = 20;
    public float radius = 10f;
    public float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
            Collider[] hitColliders_jhj = Physics.OverlapSphere(transform.position, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
            int i = 0;
            while (i < hitColliders_jhj.Length)
            {

                if (hitColliders_jhj[i].tag == "Monster") // ���͵鸸�� �˰�
                {

                    Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                    m.OngreDamage(p_damage_jhj);

                    Debug.Log("��" + p_damage_jhj + "������!!");
                }
                i++;

            }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrenadeLevelup()
    {
        
        p_damage_jhj += 5;

    }
}
