using UnityEngine;
using UnityEngine.UI;

public class ChoosedItem : MonoBehaviour
{
    private Button item;
    private bool isOn;
    private bool isTrue;
    private bool selectedTrue;
    private bool isSelected;
    
    public void SetIsTrue(bool a)
    {
        isTrue = a;
    }

    public void SetSelectedTrue(bool a)
    {
        selectedTrue = a;
    }
    
    public bool CheckIfCorrect()
    {
        return isTrue == selectedTrue;
    }
    public void SetIsSelected(bool a)
    {
        isSelected = a;
    }
    public bool GetIsSelected()
    {
        return isSelected;
    }
    
    public bool GetIsOn()
    {
        return isOn;
    }
    
    public void SetIsOn(bool a)
    {
        isOn = a;
    }
    public bool GetSelectIsTrue()
    {   
        return selectedTrue;
    }
   
}
