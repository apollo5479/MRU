using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridManager : MonoBehaviour
{
    public GridCell[] allThemGrids;
    public Row[] inputSequence;
    public int sizeMultiplier = 3;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        allThemGrids = GetComponentsInChildren<GridCell>();
        canvas = this.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonUp(0))
        {
            canvas.enabled = !canvas.enabled;
            // For every grid cell in the 1D array that has been pressed recently,
            // Place a true in the recorded sequence array at the corresponding 2D index.
            for (int i = 0; i < allThemGrids.Length; i++)
            {
                if (allThemGrids[i].isHighlighted)
                {
                    inputSequence[i%3].Cells[i/3] = true;
                }
            }
        }
    }

    [System.Serializable]
    public class Row
    {
        public bool[] Cells;
    }
}
