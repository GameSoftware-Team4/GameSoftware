using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject rangeSkill_jhj; // 범위 스킬용 오브젝트 생성
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            GameObject skill = Instantiate(rangeSkill_jhj); //범위 스킬 오브젝트를 생성하고 일정시간후 프리펩을 제거
            Destroy(skill,0.5f);
        }
        
    }

}
