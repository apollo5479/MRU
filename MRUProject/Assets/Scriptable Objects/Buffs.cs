using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Buffs", order = 1)]

public class Buffs : Ability
{
    public int buffStrength;
    public override void trigger(GameObject user)
    {
        /**
        Damage reff = user.GetComponent<Damage>();
        reff.shieldOn = true;
        */
    }
}
