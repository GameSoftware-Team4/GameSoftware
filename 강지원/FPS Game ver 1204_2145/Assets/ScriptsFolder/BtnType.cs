using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static SceneLoad;
public class BtnType : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
  { public BTNType currentType;
    public Transform buttonScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public Vector3 defaultScale;
    bool isSound;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                Debug.Log("새게임");
                SceneLoad.LoadSceneHandle("Play", 1);
                break;    
            case BTNType.Continue:
                Debug.Log("이어하기");
                SceneLoad.LoadSceneHandle("Play", 1);
                break;
            case BTNType.Sound:
                Debug.Log("소리설정");
                if(isSound)
                {
                   
                    Debug.Log("사운드OFF");
                }
                else
                {
                    Debug.Log("사운드ON");
                }
                isSound = !isSound;
                break;
            case BTNType.Back:
                Debug.Log("뒤로가기");
                break;
            case BTNType.Quit:
                Application.Quit();
                Debug.Log("종료하기");
                break;
            case BTNType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        buttonScale.localScale = defaultScale*1.2f;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
       buttonScale.localScale = defaultScale;
    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

}
