using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidZone : MonoBehaviour
{
    public int energy = 3;
    [SerializeField] private int currentEnergy;
    private VoidGuardian voidGuardian;
    void Start()
    {
        currentEnergy = energy;
        voidGuardian = GetComponentInParent<VoidGuardian>();
    }

    public void RemoveVoidEnergy(int damage){
        currentEnergy -= damage;
        if (currentEnergy <= 0) voidGuardian.isZoneDepleted = true;
    }
}
