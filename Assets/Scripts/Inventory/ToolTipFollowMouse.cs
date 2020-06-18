using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipFollowMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 mosPos = Input.mousePosition;
        if(mosPos.x + 180 > Screen.width){
            mosPos.x = Screen.width - 180;
        }
        if(mosPos.y - 120 < -Screen.height){
            mosPos.y = Screen.height + 120;
        }
        transform.position = mosPos;
    }
}
