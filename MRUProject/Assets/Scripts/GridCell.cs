using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GridCell : MonoBehaviour, IPointerEnterHandler
{
    public bool isHighlighted;
    private Image image;
    void Start()
    {
        image = this.GetComponent<Image>();
        image.color = Color.grey;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // This runs when the mouse comes into contact
        isHighlighted = true;
        image.color = Color.cyan;
    }

    public void Reset()
    {
        isHighlighted = false;
        image.color = Color.grey;
    }
}
