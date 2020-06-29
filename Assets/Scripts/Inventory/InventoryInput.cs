using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject inventoryGameObject;
    [SerializeField] GameObject equipmentGameObject;
    [SerializeField] KeyCode[] toggleInventoryKeys;
    [SerializeField] KeyCode[] toggleEquipmentKeys;
    [SerializeField] KeyCode[] toggleBothKeys;
    private bool inventoryIsActive;
    private bool equipmentIsActive;
    private CanvasGroup inventoryCanvasGroup;
    private CanvasGroup equipmentCanvasGroup;

    void Start(){
        inventoryIsActive = false;
        equipmentIsActive = false;
        inventoryCanvasGroup = inventoryGameObject.GetComponent<CanvasGroup>();
        equipmentCanvasGroup = equipmentGameObject.GetComponent<CanvasGroup>();
    }
    void Update()
    {
        for (int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            if(Input.GetKeyDown(toggleInventoryKeys[i])){
                inventoryIsActive = !inventoryIsActive;
                inventoryCanvasGroup.alpha = inventoryIsActive ? 1 : 0;
                inventoryCanvasGroup.blocksRaycasts = inventoryIsActive;
                break;
            }
            if(Input.GetKeyDown(toggleEquipmentKeys[i])){
                equipmentIsActive = !equipmentIsActive;
                equipmentCanvasGroup.alpha = equipmentIsActive ? 1 : 0;
                equipmentCanvasGroup.blocksRaycasts = equipmentIsActive;
                break;
            }
            if(Input.GetKeyDown(toggleBothKeys[i])){
                inventoryIsActive = false;
                equipmentIsActive = false;
                inventoryCanvasGroup.alpha = 0;
                inventoryCanvasGroup.blocksRaycasts = false;
                equipmentCanvasGroup.alpha = 0;
                equipmentCanvasGroup.blocksRaycasts = false;
            }
        }
    }
}
