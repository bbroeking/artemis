using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private Text tooltipText;
    private CanvasGroup cvg;
    void Start()
    {
        tooltipText = GetComponentInChildren<Text>();
        cvg = gameObject.GetComponent<CanvasGroup>();
        HideTooltip();
    }

    public void GenerateTooltip(Loot loot)
    {
        string statText = "";
        if(loot.stats != null && loot.stats.Count > 0)
        {
            foreach(var stat in loot.stats)
            {
                statText += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n";
            }
        }
        string tooltip = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>",
            loot.lootName, loot.description, statText);
        tooltipText.text = tooltip;
        ShowTooltip();
    }

    public void ShowTooltip(){
        cvg.alpha = 1;
        cvg.blocksRaycasts = true;
    }
    public void HideTooltip(){
        cvg.alpha = 0;
        cvg.blocksRaycasts = false;
    }
}
