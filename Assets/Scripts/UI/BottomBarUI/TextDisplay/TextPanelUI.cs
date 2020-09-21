using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPanelUI : MonoBehaviour
{
    [SerializeField] TextDisplayUI[] textDisplay;
    private int[] texts;
    private void OnValidate()
    {
        textDisplay = GetComponentsInChildren<TextDisplayUI>();
    }

    public void SetTexts(params int[] chartexts){
        texts = chartexts;
        if (texts.Length > textDisplay.Length)
		{
			Debug.LogError("Not Enough Stat Displays!");
			return;
		}
        for(int i = 0; i < textDisplay.Length; i++){
            textDisplay[i].gameObject.SetActive(i < texts.Length);
        }
    }

    public void UpdateTextsValues()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            textDisplay[i].ValueText.text = texts[i].ToString();
        }
    }
}
