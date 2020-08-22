using UnityEngine;

public class FloorSoul : MonoBehaviour
{
    [SerializeField] int amount = 1;
    [SerializeField] Player player;
    [SerializeField] SoulPanel soulPanel;

    void Start(){
        player = PlayerSingleton.Instance.player;
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("player")) AttractCurrency(other.transform);
        if (Vector3.Distance(this.transform.position, other.transform.position) < 0.75){
            player.Souls = amount;
            player.SetPlayerCurrency();
            Destroy(this.gameObject);
        }
    }

    void AttractCurrency(Transform target){
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime*1);
    }
}
