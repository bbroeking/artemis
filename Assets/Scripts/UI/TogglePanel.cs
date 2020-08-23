using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    protected bool active;
    [SerializeField] protected CanvasGroup canvasGroup;

    public virtual void Awake() {
        active = true;
        canvasGroup = GetComponent<CanvasGroup>();
        Toggle();
    }
    public void Toggle(){
        if(active){
            HidePanel();
            active = false;
        } else {
            ShowPanel();
            active = true;
        }
    }
    protected void ShowPanel(){
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    protected void HidePanel(){
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
