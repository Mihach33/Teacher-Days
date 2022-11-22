using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CountryEvent : EventTrigger
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        CountryClicker.Instance.CheckIfProperCountryClicked(gameObject);
        base.OnPointerClick(eventData);
    }
}
