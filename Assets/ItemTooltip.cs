using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemSlotText;
    [SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(EquippableItem item)
    {   
        ItemNameText.text = item.name;
        ItemSlotText.text = item.EquipmentType.ToString();

        sb.Length = 0;
        
        AddStat(item.strengthBonus, "strength");
        AddStat(item.dexterityBonus, "dexterity");
        AddStat(item.intellectBonus, "intellect");
        AddStat(item.vitalityBonus, "vitality");

        ItemStatsText.text = sb.ToString();

        gameObject.SetActive(true);
    }

    public void HideTooltip(){
        gameObject.SetActive(false);
    }

    private void AddStat(float value, string statName){
        if (sb.Length > 0)
            sb.AppendLine();

        if(value != 0){
            sb.Append(value);
            sb.Append(" ");
            sb.Append(statName);
        }
    }
}
