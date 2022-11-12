using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{   public static string loadScene = "Loading";
    public static int loadType;
    public Slider progressbar;
    public Text loadtext;
    public static void LoadSceneHandle(string _name, int _loadType)
    {
        loadScene = _name;
        loadType = _loadType;
        SceneManager.LoadScene(loadType);
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadScene);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            yield return null;
            if(loadType == 0)
                Debug.Log("새게임");
            else if(loadType == 1)
                Debug.Log("헌게임");
            if(progressbar.value < 1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            else
            {
                loadtext.text = "Press SpaceBar";
            }
            if(Input.GetKeyDown(KeyCode.Space)&& progressbar.value >= 1f&& operation.progress >= 0.9f){
                operation.allowSceneActivation = true;
                SceneManager.LoadScene("MapScene");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
