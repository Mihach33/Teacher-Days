using TMPro;
using UnityEngine;

public class ResolutionDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownResolution;

    private void Start()
    {
        dropdownResolution = GetComponent<TMP_Dropdown>();
    }

    public void ChangeResolution()
    {
        switch (dropdownResolution.value)
        {
            case 0:
                Screen.SetResolution(1366,768,true);
                break;
            case 1:
                Screen.SetResolution(1920,1080,true);
                break;
            case 2:
                Screen.SetResolution(2560,1440,true);
                break;
            case 3:
                Screen.SetResolution(3840,2160,true);
                break;
        }
    }

    
}
