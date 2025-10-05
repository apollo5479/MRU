using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ability", order = 1)]
public class Ability : ScriptableObject
{
    public string abilityName;
    public int damage;
    public aRow[] sequence;
    public float cooldown;
    public GameObject abilityPrefab;
    public virtual void trigger(GameObject user)
    {
        if (abilityPrefab != null)
        {
            Instantiate(abilityPrefab, user.transform.position, Quaternion.identity);
            Debug.Log("Triggered " + abilityName);
        }
    }

    [System.Serializable]
    public class aRow
    {
        public bool[] Cells;
    }
}
