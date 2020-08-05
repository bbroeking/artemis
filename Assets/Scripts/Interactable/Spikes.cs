using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Interactable
{
    public Collider2D spikesHitbox;
    private float disableTime = 0.5f;
    private int spikeDamage = 1;
    private int spikesCooldown = 2;
    private bool isInteractable = true;
    private IEnumerator Cooldown(){
        isInteractable = false;
        yield return new WaitForSeconds(spikesCooldown);
        isInteractable = true;
    }

    public override void Interact(Player player){
        if (isInteractable){
            StartCoroutine(Cooldown());
            player.TakeDamage(spikeDamage);
            var magnitude = 550;
            var force = transform.position - player.transform.position;
            force.Normalize();
            player.GetComponent<Rigidbody2D>().AddForce(-force * magnitude);
            StartCoroutine(player.disableMovement(disableTime));
        }
    }

    public override void StopInteract(){

    }
}
