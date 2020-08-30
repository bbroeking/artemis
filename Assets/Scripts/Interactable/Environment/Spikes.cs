using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Interactable
{
    public Collider2D spikesHitbox;
    private float disableTime = 0.5f;
    private float magnitude = 500f;
    private int spikeDamage = 1;
    private int spikesCooldown = 2;

    public override void Interact(Player player){
        if (player.canInteract){
            player.Hit(spikeDamage);
            player.KnockPlayer(this.transform, magnitude, disableTime);
        }
    }

    public override void StopInteract(){

    }
}
