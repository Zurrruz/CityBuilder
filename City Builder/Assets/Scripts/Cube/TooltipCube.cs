using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipCube : MonoBehaviour, IPointerClickHandler
{
    public delegate void TooltipBox(string name, string size);
    public static event TooltipBox tooltipeBox;

    [SerializeField]
    string _name;
    [SerializeField]
    string _size;

    public void OnPointerClick(PointerEventData eventData)
    {
        tooltipeBox(_name, _size);
        TooltipeController.cube = gameObject;
    }    
}
