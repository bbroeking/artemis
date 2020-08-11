using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Interactable
{
    public Collider2D spikesHitbox;
    private float disableTime = 0.5f;
    private float magnitude = 250f;
    private int spikeDamage = 1;
    private int spikesCooldown = 2;

    public override void Interact(Player player){
        if (isInteractable){
            StartCoroutine(Cooldown());
            player.TakeDamage(spikeDamage);
            player.KnockPlayer(this.transform, magnitude);
            StartCoroutine(player.DisableMovement(disableTime));
        }
    }

    public override void StopInteract(){

    }
}
