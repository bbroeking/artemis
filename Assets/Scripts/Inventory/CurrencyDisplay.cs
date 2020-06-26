using UnityEngine;
using TMPro;

public class CurrencyDisplay : MonoBehaviour
{
    public TextMeshProUGUI ValueText;

    private void OnValidate()
    {
        ValueText = GetComponentInChildren<TextMeshProUGUI>();
    }
}
