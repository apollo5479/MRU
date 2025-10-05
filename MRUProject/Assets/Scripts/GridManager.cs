using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridManager : MonoBehaviour
{
    public Abilities abilities;
    public GridCell[] allThemGrids;
    public Row[] inputSequence;
    public int sizeMultiplier = 3;
    public Canvas canvas;
    private bool isHolding;
    // Start is called before the first frame update
    void Start()
    {
        allThemGrids = GetComponentsInChildren<GridCell>();
        canvas = this.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleGridToggle();
        HandleInput();
    }
    private void HandleGridToggle()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Show the grid
            canvas.enabled = true;
            isHolding = true;
            ResetInputSequence();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            // Hide the grid
            canvas.enabled = false;
            isHolding = false;
            foreach (Ability ability in abilities.abilities)
            {
                if (SequencesMatch(inputSequence, ability.sequence))
                {
                    AbilityManager.Instance.UnlockAbility(ability);
                    AbilityManager.Instance.UseAbility(ability);
                }
            }
            ResetInputSequence();
        }
    }
    private void ResetInputSequence()
    {
        for (int i = 0; i < allThemGrids.Length; i++)
        {
            allThemGrids[i].Reset();
            inputSequence[i / sizeMultiplier].Cells[i % sizeMultiplier] = false;
        }
    }
    private bool SequencesMatch(Row[] input, Ability.aRow[] abilitySequence)
    {
        if (input.Length != abilitySequence.Length) return false;

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Cells.Length; j++)
            {
                if (input[i].Cells[j] != abilitySequence[i].Cells[j])
                {
                    return false;
                }
            }
        }
        return true;
    }
    private void HandleInput()
    {
        if (!isHolding) return;

        // Record which cells are highlighted
        for (int i = 0; i < allThemGrids.Length; i++)
        {
            // For every grid cell in the 1D array that has been pressed recently,
            // Place a true in the recorded sequence array at the corresponding 2D index.
            if (allThemGrids[i].isHighlighted)
            {
                inputSequence[i / 3].Cells[i % 3] = true;
            }
        }

    }
    [System.Serializable]
    public class Row
    {
        public bool[] Cells;
    }
}
