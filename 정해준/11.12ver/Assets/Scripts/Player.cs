using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject rangeSkill_jhj; // ���� ��ų�� ������Ʈ ����
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            GameObject skill = Instantiate(rangeSkill_jhj); //���� ��ų ������Ʈ�� �����ϰ� �����ð��� �������� ����
            Destroy(skill,0.5f);
        }
        
    }

}
