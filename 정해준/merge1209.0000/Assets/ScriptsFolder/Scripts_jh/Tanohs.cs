using UnityEngine;
using System.Collections;

public class Tanohs : MonoBehaviour
{
    public float t_damage_jhj = 100f;
    public float radius = 110f;
    public GameObject eff;

    // Start is called before the first frame update
    IEnumerator T_attatck()
    {
        yield return new WaitForSeconds(10f);
        Collider[] hitColliders_jhj = Physics.OverlapSphere(gameObject.transform.position, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
        int i = 0;

        while (i < hitColliders_jhj.Length)
        {

            if (hitColliders_jhj[i].tag == "Monster") // ���͵鸸�� �˰�
            {

                Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                m.OngreDamage(t_damage_jhj);

                Debug.Log("������ ����!" + t_damage_jhj + "������!!");
            }
            i++;

        }



    }
    void Start()
    {
        eff = Resources.Load<GameObject>("T_skill");
        T_attatck();
        StartCoroutine(T_attatck());
    }

}



