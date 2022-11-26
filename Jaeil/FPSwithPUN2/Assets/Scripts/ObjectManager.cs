using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ObjectManager : MonoBehaviour
{
    float currentTime;
    public float createTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        createTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            GameObject obj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Object"), transform.position, transform.rotation);
            currentTime = 0;
            Destroy(obj, 30f);
        }
    }
}
