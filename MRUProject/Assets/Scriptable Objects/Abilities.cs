using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Abilities", order = 1)]
public class Abilities : ScriptableObject
{
    public List<Ability> abilities;
}
