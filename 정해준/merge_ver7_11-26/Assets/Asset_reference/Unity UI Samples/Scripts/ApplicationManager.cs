using UnityEngine;
using System.Collections;
using System.Collections.Generic; //추가
using UnityEngine.SceneManagement; // 추가

public class ApplicationManager : MonoBehaviour {

	public void PlayBtn() //추가
	{
		SceneManager.LoadScene("Loading");
		print("hi");
	}

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
