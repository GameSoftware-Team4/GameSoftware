using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    public Texture2D aimTexture;
    public Rect aimRect;

    // Start is called before the first frame update
    void Start()
    {
        aimRect = new Rect((Screen.width - aimTexture.width) / 2, (Screen.height - aimTexture.height) / 2, aimTexture.width, aimTexture.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUI.DrawTexture(aimRect, aimTexture);
    }
}
