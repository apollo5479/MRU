using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ability", order = 1)]
public class Ability : ScriptableObject
{
    public string abilityName;
    public string animationName;
    public int damage;
    public aRow[] sequence;
    public float cooldown;
    public GameObject abilityPrefab;
    public GameObject HitboxField2;
    public GameObject HitboxField3;
    public GameObject HitboxField4;
    //public GameObject me;


    public virtual void trigger(GameObject user)
    {
        if (abilityPrefab != null)
        {
            GameObject prefab = Instantiate(abilityPrefab, user.transform.position, Quaternion.identity);
            Animator animator = user.GetComponent<Animator>();
            animator.Play(animationName);
            Debug.Log("Triggered " + abilityName);
            if (abilityName == "Long Attack") {
                Debug.Log("BROOOOOOOOOO");
                Instantiate(HitboxField2, user.transform.position, Quaternion.identity);
            }
            if (abilityName == "Shield")
            {
                Debug.Log("BROOOOOOOOOO");
                Instantiate(HitboxField3, user.transform.position, Quaternion.identity);
            }
            if (abilityName == "Fire Sphere")
            {
                Debug.Log("BROOOOOOOOOO");
                Instantiate(HitboxField4, user.transform.position, Quaternion.identity);

            }
        }
    }

    [System.Serializable]
    public class aRow
    {
        public bool[] Cells;
    }
}
