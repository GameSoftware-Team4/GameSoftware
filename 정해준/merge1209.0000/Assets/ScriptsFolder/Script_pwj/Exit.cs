using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using System.IO;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private float tm = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExitTime(5));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // 어플리케이션 종료
#endif
    }
    IEnumerator ExitTime(float cool)
    {
        yield return new WaitForSeconds(cool);
        SceneManager.LoadScene(0);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();

    }

}