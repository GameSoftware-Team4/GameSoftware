using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlaySound : MonoBehaviourPunCallbacks
{
    
    public AudioClip clipp;
    public AudioSource sunet;

    void Start()
    {
        
        sunet = GetComponent<AudioSource>();
        sunet.clip = clipp;
        photonView.RPC("PlayAudio", RpcTarget.All);

    }

    [PunRPC]
    void PlayAudio()
    {
        
        sunet.Play();
    }

}
