using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform castPos;
    public Collider2D playerCollider;
    public LayerMask whatIsEnemy;
    public float spellForce;
    private bool isCooldown = false;
    [SerializeField] GameObject gravitySoul;
    [SerializeField] GameObject poisonNova;

    [Header("Hitbox")]
    [SerializeField] private GameObject rightHitbox;
    [SerializeField] private GameObject leftHitbox;
    [SerializeField] private GameObject topHitbox;
    [SerializeField] private GameObject bottomHitbox;
    
    [Header("Components")]
    [SerializeField] private Player player;
    [SerializeField] private Spellbook spellbook;
    [SerializeField] private PlayerResources resources;
    [SerializeField] private CanvasGroup inventoryCanvasGroup;
    [SerializeField] private CanvasGroup equipmentCanvasGroup;
    [SerializeField] private Animator anim;

    void Update()
    {
        if(!inventoryCanvasGroup.blocksRaycasts && !equipmentCanvasGroup.blocksRaycasts){
            if (Input.GetButtonDown("Fire1"))
            {
                if(!isCooldown){
                    SpawnMeleeWave();
                    anim.SetTrigger("Attack");
                    CheckHitbox();
                    StartCoroutine(Cooldown());
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

    private void SpawnMeleeWave(){
        string pathToPrefab = "Projectiles/PlayerProjectiles/MeleeWave";
        GameObject wave = (GameObject) LoadPrefab.LoadPrefabFromFile(pathToPrefab);
        Instantiate(wave);
    }

    private void CheckHitbox(){
        if(player.lastMoveDirection == MoveDirection.Up){
            StartCoroutine(CheckHitBoxEnabler(topHitbox));
        }
        else if(player.lastMoveDirection == MoveDirection.Down){
            StartCoroutine(CheckHitBoxEnabler(bottomHitbox));

        }
        else if(player.lastMoveDirection == MoveDirection.Left){
            StartCoroutine(CheckHitBoxEnabler(leftHitbox));

        }
        else if(player.lastMoveDirection == MoveDirection.Right){
            StartCoroutine(CheckHitBoxEnabler(rightHitbox));
        }
    }

    private IEnumerator CheckHitBoxEnabler(GameObject hitbox){
        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        hitbox.SetActive(false);
    }

    private IEnumerator Cooldown()
    {
        // Start cooldown
        isCooldown = true;
        // Wait for time you want
        yield return new WaitForSeconds(player.InteralAttackCooldown);
        // Stop cooldown
        isCooldown = false;
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
