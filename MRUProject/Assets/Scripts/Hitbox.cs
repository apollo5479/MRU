using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private Ability ability;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameMobBehaviour enemy = other.GetComponent<GameMobBehaviour>();

        if (enemy != null)
        {
            //enemy.TakeDamage(ability.damage);
        }
    }
}
