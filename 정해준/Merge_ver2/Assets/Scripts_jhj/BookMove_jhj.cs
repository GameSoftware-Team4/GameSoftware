using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMove_jhj : MonoBehaviour
{
    GameObject target_jhj; //주위를 돌때 중심이 되는 물체

    float b_yPosition_jsj = 0.7f;  //y축 위치

    float b_radius_jhj = 2.0f;   // 이동하는 반지름의 크기

    public float b_angularVelocity_jhj = 360.0f; //속도

    public float b_angle_jhj = 0.0f; //각도

    float b_degreePersecond_jhj = 200;  //주변을 돌 때 물체자체가 회전할 때 초당 움직이는 위치
    // Update is called once per frame
    void Start()
    {
        target_jhj = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * b_degreePersecond_jhj);
        transform.Rotate(Vector3.right * Time.deltaTime * b_degreePersecond_jhj); //오브젝트가 회전

        b_angle_jhj += b_angularVelocity_jhj * Time.deltaTime;

        Vector3 offset_jhj = Quaternion.Euler(0.0f, b_angle_jhj, 0.0f) * new Vector3(0.0f, 0.0f, b_radius_jhj);

        transform.position = new Vector3(target_jhj.transform.position.x, b_yPosition_jsj, target_jhj.transform.position.z) + offset_jhj;
    }
}
