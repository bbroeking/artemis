using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Collider2D spikesHitbox;
    private int spikesCooldown = 4;
    private int spikesDuration = 2;
    private bool isCooldown = false;
    private bool isActive = false;
    void Start(){
        spikesHitbox.enabled = false;
    }
    void Update(){
        if (!isCooldown && !isActive){
            StartCoroutine(Cooldown());
        } else if (isActive && !isCooldown){
            StartCoroutine(Duration());
        }
    }

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(spikesCooldown);
        isCooldown = false;
        spikesHitbox.enabled = true;
        isActive = true;
    }

    private IEnumerator Duration(){
        yield return new WaitForSeconds(spikesCooldown);
        isActive = false;
        spikesHitbox.enabled = false;
    }

}
