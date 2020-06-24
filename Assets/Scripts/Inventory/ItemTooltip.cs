using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemTypeText;
	[SerializeField] Text ItemDescriptionText;

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(Item item)
    {   
        ItemNameText.text = item.name;
		ItemTypeText.text = item.GetItemType();
		ItemDescriptionText.text = item.GetDescription();
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
