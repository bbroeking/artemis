using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPanel : MonoBehaviour
{
    [SerializeField] SoulDisplay[] statDisplays;
    private int[] currency;
    private void OnValidate()
    {
        statDisplays = GetComponentsInChildren<SoulDisplay>();
    }

    public void SetCurrency(params int[] charCurrency){
        currency = charCurrency;
        if (currency.Length > statDisplays.Length)
		{
			Debug.LogError("Not Enough Stat Displays!");
			return;
		}
        for(int i = 0; i < statDisplays.Length; i++){
            statDisplays[i].gameObject.SetActive(i < currency.Length);
        }
    }

    public void UpdateCurrencyValues()
    {
        for (int i = 0; i < currency.Length; i++)
        {
            statDisplays[i].ValueText.text = currency[i].ToString();
        }
    }
}
