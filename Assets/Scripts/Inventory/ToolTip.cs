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
        string tooltip;
        LootEquipment eq = loot as LootEquipment;
        if (eq != null){
            if(eq.stats != null && eq.stats.Count > 0)
            {
                foreach(var stat in eq.stats)
                {
                    statText += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n";
                }
            }
            tooltip = string.Format("<b>{0}</b>\n{1}\n Type: {2}\n\n<b>{3}</b>",
                                    eq.lootName, eq.description, eq.equipmentType, statText);
        } else {
            tooltip = string.Format("<b>{0}</b>\n{1}\n Type: {2}\n\n<b>{3}</b>", 
                                    loot.lootName, loot.description, loot.lootType, statText);
        }
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
