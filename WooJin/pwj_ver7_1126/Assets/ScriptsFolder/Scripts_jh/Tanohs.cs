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
        Collider[] hitColliders_jhj = Physics.OverlapSphere(transform.position, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            if (hitColliders_jhj[i].tag == "Monster") // ���͵鸸�� �˰�
            {
                GameObject g = Instantiate(eff, hitColliders_jhj[i].transform);
                Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                m.OngreDamage(t_damage_jhj);
                Destroy(g, 4f);
                Debug.Log("������ ����!" + t_damage_jhj + "������!!");
            }
            i++;

        }


    }

    // Update is called once per frame
    void Update()
    {

    }

}



