using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Transform attackPos;
    public Transform castPos;
    public GameObject gravitySoul;
    public Collider2D playerCollider;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public float spellForce;
    private float timeBetweenAttack;
    [SerializeField] private GameObject poisonNova;
    
    [Header("Components")]
    [SerializeField] private Player player;
    [SerializeField] private Spellbook spellbook;
    [SerializeField] private PlayerResources resources;
    [SerializeField] private GameObject inventoryGameObject;
    [SerializeField] private GameObject equipmentGameObject;

    void Update()
    {
        if(!inventoryGameObject.activeSelf && !equipmentGameObject.activeSelf){
            if (Input.GetButtonDown("Fire1"))
            {
                if(timeBetweenAttack <= 0){
                    Melee();
                    timeBetweenAttack = player.InteralAttackCooldown;
                } else {
                    timeBetweenAttack -= Time.deltaTime;
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                if(resources.GetActiveEssenceAmount() > 0){
                    Soul active = resources.ActiveSoul;
                    if(active == Soul.gravity){
                        Cast(gravitySoul, castPos);
                    }
                    else if(active == Soul.poison){
                        Cast(poisonNova, castPos);
                    }
                    resources.UseEssence(1);
                }
            }
            if (Input.GetKeyDown("e"))
            {
                resources.SwapActiveSoul();
            }
            if (Input.GetKeyDown("q"))
            {
                int activeEssenceAmount = resources.GetActiveEssenceAmount();
                if(activeEssenceAmount > 3){
                    StartCoroutine(CastSoulAbility(resources.ActiveSoul));
                }
            }
        }
    }
    void Melee(){
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().Hit(player.SpellDamage);
        }
    }
    void Cast(GameObject b, Transform firePoint)
    {
        GameObject spell = Instantiate(b, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(spell.GetComponent<Collider2D>(), playerCollider);

        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        Vector2 lookDir = worldPosition - rb.position;

        rb.AddForce(lookDir.normalized * spellForce, ForceMode2D.Impulse);
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    private void SoulAbility(Soul activeSoul){
        if (activeSoul == Soul.poison){
            spellbook.PoisonNova(poisonNova, castPos.transform, playerCollider);
        }
    }
    public IEnumerator CastSoulAbility(Soul activeSoul){
        for (int i = 0; i < 6; i++)
        {
            SoulAbility(activeSoul);
            yield return new WaitForSeconds(1f);
        }
    }
}
