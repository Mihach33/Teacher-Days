using UnityEngine.EventSystems;

public class CountryEvent : EventTrigger
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        CountryClicker.Instance.CheckIfProperCountryClicked(gameObject);
        base.OnPointerClick(eventData);
    }
}