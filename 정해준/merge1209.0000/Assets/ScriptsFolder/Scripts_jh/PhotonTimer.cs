using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class PhotonTimer : MonoBehaviourPunCallbacks, IPunObservable
{
    System.DateTime startTime = System.DateTime.UtcNow;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(startTime.Ticks);
        }
        else
        {
            startTime = new System.DateTime((long)stream.ReceiveNext());
        }
    }
    public void SetTimer()
    {
        timer = oneGameTime - ((System.DateTime.UtcNow.Ticks - startTime.Ticks) / 1000000);
        timer = Mathf.Clamp(0, timer, oneGameTime);
        timerUI.text = timer.ToString();
    }
    static readonly float oneGameTime = 720;
    float timer = oneGameTime;
    public Text timerUI;
}
