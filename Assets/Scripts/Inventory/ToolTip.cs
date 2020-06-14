using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private Text tooltipText;
    void Start()
    {
        tooltipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    public void GenerateTooltip(Loot loot)
    {
        string statText = "";
        if(loot.stats.Count > 0)
        {
            foreach(var stat in loot.stats)
            {
                statText += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n";
            }
        }
        string tooltip = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>",
            loot.lootName, loot.description, statText);
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
