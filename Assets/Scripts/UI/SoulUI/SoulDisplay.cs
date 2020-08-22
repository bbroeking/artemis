using UnityEngine;
using TMPro;

public class SoulDisplay : MonoBehaviour
{
    public TextMeshProUGUI ValueText;

    private void OnValidate()
    {
        ValueText = GetComponentInChildren<TextMeshProUGUI>();
    }
}
