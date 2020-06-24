using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject inventoryGameObject;
    [SerializeField] GameObject equipmentGameObject;
    [SerializeField] KeyCode[] toggleInventoryKeys;
    [SerializeField] KeyCode[] toggleEquipmentKeys;
    void Update()
    {
        for (int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            if(Input.GetKeyDown(toggleInventoryKeys[i])){
                inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
                break;
            }
            if(Input.GetKeyDown(toggleEquipmentKeys[i])){
                equipmentGameObject.SetActive(!equipmentGameObject.activeSelf);
                break;
            }
        }
    }
}
