using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMove_jhj : MonoBehaviour
{
    GameObject target_jhj; //������ ���� �߽��� �Ǵ� ��ü

    float b_yPosition_jsj = 0.7f;  //y�� ��ġ

    float b_radius_jhj = 2.0f;   // �̵��ϴ� �������� ũ��

    public float b_angularVelocity_jhj = 360.0f; //�ӵ�

    public float b_angle_jhj = 0.0f; //����

    float b_degreePersecond_jhj = 200;  //�ֺ��� �� �� ��ü��ü�� ȸ���� �� �ʴ� �����̴� ��ġ
    // Update is called once per frame
    void Start()
    {
        target_jhj = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * b_degreePersecond_jhj);
        transform.Rotate(Vector3.right * Time.deltaTime * b_degreePersecond_jhj); //������Ʈ�� ȸ��

        b_angle_jhj += b_angularVelocity_jhj * Time.deltaTime;

        Vector3 offset_jhj = Quaternion.Euler(0.0f, b_angle_jhj, 0.0f) * new Vector3(0.0f, 0.0f, b_radius_jhj);

        transform.position = new Vector3(target_jhj.transform.position.x, b_yPosition_jsj, target_jhj.transform.position.z) + offset_jhj;
    }
}
