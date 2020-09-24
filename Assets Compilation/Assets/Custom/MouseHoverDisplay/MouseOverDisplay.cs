using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Descirpton");
    }
     
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Descirpton exit");

    }
}
