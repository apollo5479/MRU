using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GridCell : MonoBehaviour, IPointerEnterHandler
{
    public bool isHighlighted;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // This runs when the mouse comes into contact
        isHighlighted = true;
        Image image = this.GetComponent<Image>();
        image.color = Color.cyan;
        Debug.Log($"Mouse entered {name}");
    }
}
