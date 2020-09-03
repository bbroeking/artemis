using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Soul { gravity, poison }
public class PlayerResources : MonoBehaviour
{
    [SerializeField] private Player player;

    [Header("UI")]
    [SerializeField] private UISingleton uISingleton;
    [SerializeField] private SanityUI sanityUI;
    // [SerializeField] private HealthBar healthbar;
    // [SerializeField] private EssenceBar activeEssence;
    // [SerializeField] private EssenceBar inactiveEssence;

    [Header("Souls")]
    [SerializeField] private Soul activeSoul;
    public Soul ActiveSoul { get { return activeSoul;} }
    [SerializeField] private Soul inactiveSoul;
    public Soul InactiveSoul { get { return inactiveSoul;} }

    [Header("Essence")]
    public int gravityEssence;
    public int poisonEssence;
    public int maxEssence;
    
    void Start() {
        uISingleton = UISingleton.Instance;
        sanityUI = uISingleton.GetComponentInChildren<SanityUI>();
        maxEssence = 5;
        activeSoul = Soul.gravity;
        inactiveSoul = Soul.poison;
        // healthbar.SetMaxHealth(player.health);
        // activeEssence.SetMaxEssence(this.maxEssence);
        // inactiveEssence.SetMaxEssence(this.maxEssence);
        this.gravityEssence = this.maxEssence;
        this.poisonEssence = this.maxEssence;
    }
    public void SetSanity()
    {
        sanityUI.SetSanity(player.CurrentHealth, player.health);
    }
    public void UseEssence(int essence){
        // if(activeSoul == Soul.gravity){
        //     this.gravityEssence -= essence;
        //     this.activeEssence.SetEssence(this.gravityEssence);
        // }
        // else if (activeSoul == Soul.poison){
        //     this.poisonEssence -= essence;
        //     this.activeEssence.SetEssence(this.poisonEssence);
        // }
    }
    public void SwapActiveSoul(){
        // Soul tempSoul = activeSoul;
        // activeSoul = inactiveSoul;
        // inactiveSoul = tempSoul;
        // EssenceBar temp = activeEssence;
        // activeEssence = inactiveEssence;
        // inactiveEssence = temp;
    }
    public int GetActiveEssenceAmount(){
        if(activeSoul == Soul.gravity){
            return this.gravityEssence;
        }
        else if (activeSoul == Soul.poison){
            return this.poisonEssence;
        }
        else {
            return 0;
        }
    }
}
