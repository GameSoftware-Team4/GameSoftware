using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript_pwj : MonoBehaviour
{
    public int totalExp = 0;
    private void Start()
    {
        
    }


    void Update()
    {
        
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
