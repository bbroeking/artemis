using UnityEngine;
using TMPro;

public class TextDisplayUI : MonoBehaviour
{
    public TextMeshProUGUI ValueText;

    private void OnValidate()
    {
        ValueText = GetComponentInChildren<TextMeshProUGUI>();
    }
}
