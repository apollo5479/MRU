using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LongAttack", order = 1)]
public class LongAttack : ScriptableObject
{
    public bool damage;
    public Row[] sequence;
    [System.Serializable]
    public class Row
    {
        public bool[] Cells;
    }
}
