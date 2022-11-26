using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{   [SerializeField]
    private Slider hpbar;
    // Start is called before the first frame update
    private float maxHp = 100;
    private float curHp = 100;
    float imsi;
    void Start()
    {
    
        hpbar.value = Mathf.Lerp(hpbar.value, (float) curHp / (float)maxHp,Time.deltaTime *10);     
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            curHp -= 10;
        }
        imsi =  (float) curHp / (float)maxHp;
        HandleHp();
    }
    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, imsi,Time.deltaTime *10);
    }
}
