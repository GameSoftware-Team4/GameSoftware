using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript_pwj : MonoBehaviour
{
    public int totalExp = 0;
    public float timeLapsed = 0;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        timeLapsed += Time.deltaTime;
    }
    public void SetExp()
    {
        totalExp += 10;
    }

    public int GetExp()
    {
        return totalExp;
    }
}
