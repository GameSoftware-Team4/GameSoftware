using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public float rotationSpeed = 30f;
    public bool flag= true;
    void Update() {
        if (flag)
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}