using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager Instance { get; private set; }

    private HashSet<Ability> unlockedAbilities = new HashSet<Ability>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    public void UnlockAbility(Ability ability)
    {
        unlockedAbilities.Add(ability);
        Debug.Log($"Unlocked: {ability.abilityName}");
    }

    public bool HasAbility(Ability ability)
    {
        return unlockedAbilities.Contains(ability);
    }

    public void ResetAbilities()
    {
        unlockedAbilities.Clear();
    }

}
