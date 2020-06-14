
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ladder")
        {
            SceneManager.LoadScene(sceneName);
        }
        if(collision.gameObject.tag == "Loot")
        {
            Loot loot = collision.gameObject.GetComponent<LootInfo>().loot;
            GetComponent<Inventory>().GiveItem(loot.id);
            Destroy(collision.gameObject);
        }
    }
}
