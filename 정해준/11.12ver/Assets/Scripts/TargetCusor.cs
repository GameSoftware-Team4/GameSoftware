using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCusor : MonoBehaviour
{
    public Transform target_jhj; //������ ���� �߽��� �Ǵ� ��ü

    float yPosition_jsj = 0.7f;  //y�� ��ġ

    float radius_jhj = 2.0f;   // �̵��ϴ� �������� ũ��

    public float angularVelocity_jhj = 360.0f; //�ӵ�

    public float angle_jhj = 0.0f; //����

    float degreePersecond_jhj = 200;  //�ֺ��� �� �� ��ü��ü�� ȸ���� �� �ʴ� �����̴� ��ġ
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * degreePersecond_jhj);
        transform.Rotate(Vector3.right * Time.deltaTime * degreePersecond_jhj); //������Ʈ�� ȸ��

        angle_jhj += angularVelocity_jhj * Time.deltaTime;

        Vector3 offset_jhj = Quaternion.Euler(0.0f, angle_jhj, 0.0f) * new Vector3(0.0f, 0.0f, radius_jhj);

        transform.position = new Vector3(target_jhj.transform.position.x, yPosition_jsj, target_jhj.transform.position.z) + offset_jhj;
    }
}
