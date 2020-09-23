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

    [Header("Projectile")]
    [SerializeField] GameObject voidProjectile;
    [SerializeField] GameObject poisonProjectile;
    [SerializeField] GameObject hellfireProjectile;
    private List<GameObject> projectiles = new List<GameObject>();
    public Vector3 shotDirection = Vector3.zero;

    [Header("Hitbox")]
    [SerializeField] private Collider2D rightHitbox;
    [SerializeField] private Collider2D leftHitbox;
    [SerializeField] private Collider2D topHitbox;
    [SerializeField] private Collider2D bottomHitbox;
    
    [Header("Components")]
    [SerializeField] private Player player;
    [SerializeField] private Spellbook spellbook;
    [SerializeField] private PlayerRelic relic;
    [SerializeField] private PlayerResources resources;
    [SerializeField] private Animator anim;

    void Start(){
        projectiles.Add(voidProjectile);
        projectiles.Add(poisonProjectile);
        projectiles.Add(hellfireProjectile);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(!isCooldown){
                anim.SetTrigger("Attack");
                SpawnMeleeWave();
                CheckHitbox();
                StartCoroutine(Cooldown());
            }
        }
        if (Input.GetKeyDown("up") ||
            Input.GetKeyDown("down") ||
            Input.GetKeyDown("left") ||
            Input.GetKeyDown("right"))
        {
            if(Input.GetKeyDown("up")) shotDirection = Vector3.up;
            else if(Input.GetKeyDown("down")) shotDirection = Vector3.down;
            else if(Input.GetKeyDown("left")) shotDirection = Vector3.left;
            else if(Input.GetKeyDown("right")) shotDirection = Vector3.right;
            if(resources.GetActiveEssenceAmount() > 0) Cast();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)) UseRelicAbility(0);
        if(Input.GetKeyDown(KeyCode.Alpha2)) UseRelicAbility(1);
        if(Input.GetKeyDown(KeyCode.Alpha3)) UseRelicAbility(2);
        if(Input.GetKeyDown(KeyCode.Alpha4)) UseRelicAbility(3);     
    }

    
    private void UseRelicAbility(int index){
        UsableItem item = relic.GetRelic(index);
        if(item == null) return;
        item.Use(player);
    }
    private void SpawnMeleeWave(){
        string pathToPrefab = "Projectiles/PlayerProjectiles/MeleeWave";
        GameObject wave = (GameObject) LoadPrefab.LoadPrefabFromFile(pathToPrefab);
        Instantiate(wave);
    }
    private void CheckHitbox(){
        Collider2D[] enemiesToDamage = new Collider2D[20]; // TODO maybe i dont want to do this?
        ContactFilter2D filter = new ContactFilter2D();
        filter.useLayerMask = true;
        filter.SetLayerMask(whatIsEnemy);

        if(player.lastMoveDirection == MoveDirection.Up){
            Physics2D.OverlapCollider(topHitbox, filter, enemiesToDamage);
        }
        else if(player.lastMoveDirection == MoveDirection.Down){
            Physics2D.OverlapCollider(bottomHitbox, filter, enemiesToDamage);
        }
        else if(player.lastMoveDirection == MoveDirection.Left){
            Physics2D.OverlapCollider(leftHitbox, filter, enemiesToDamage);
        }
        else if(player.lastMoveDirection == MoveDirection.Right){
            Physics2D.OverlapCollider(rightHitbox, filter, enemiesToDamage);
        }

        for (int enem = 0; enem < enemiesToDamage.Length; enem++){
            if (enemiesToDamage[enem] == null) break;
            enemiesToDamage[enem].GetComponent<Enemy>().Hit(player.BaseDamage);
        }
    }
    void Cast()
    {
        int num = Random.Range(0, 3);
        GameObject GO = ObjectPooler.SharedInstance.GetPooledObject(num * 2);
        Projectile projectile = GO.GetComponent<Projectile>();
        projectile.Init(0, 0, 2,
                        0, 1, this.transform.position,
                        0, 0, Vector3.zero);
        GO.SetActive(true);
        ProjectileHelpers.ObjectIgnores(GO, playerCollider);
    }
    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(player.InteralAttackCooldown);
        isCooldown = false;
    }

    public void ExecuteRelicEffect(RelicType type){
        if (type == RelicType.Nova) spellbook.PoisonNova(castPos.transform);
        if (type == RelicType.Beam) spellbook.PoisonBeam(castPos.transform);
        if (type == RelicType.Fang) spellbook.PoisonFang(castPos.transform);
    }
}
