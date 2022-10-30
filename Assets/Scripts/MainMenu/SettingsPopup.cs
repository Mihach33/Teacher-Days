using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    private bool _pageSliderGo = false;
    [SerializeField] private Slider _loadingPageSlider;
    [SerializeField] private GameObject _settingsPop;
    [SerializeField] private Button _settingsOpenButton;
    [SerializeField] private Button _backToMainButton;

    void Start()
    {
        _loadingPageSlider.gameObject.SetActive(false);
        _settingsPop.SetActive(false);
        _settingsOpenButton.onClick.AddListener(SetSettings);
        _backToMainButton.onClick.AddListener(SetSettings);
    }
    
    
    private void SetSettings()
    {
        TurnButtons();
        _loadingPageSlider.gameObject.SetActive(true);
        _loadingPageSlider.value = 0;
        _pageSliderGo = true;
    }

    private void TurnButtons()
    {
        _backToMainButton.enabled = !_backToMainButton.enabled;
        _settingsOpenButton.enabled = !_settingsOpenButton.enabled;
    }


    private void FixedUpdate()
    {
        if (_pageSliderGo)
        {
            _loadingPageSlider.value += Time.deltaTime;
            if (_loadingPageSlider.value == 1)
            {
                TurnButtons();
                _loadingPageSlider.gameObject.SetActive(false);
                _pageSliderGo = false;
                _loadingPageSlider.value = 0;
                _settingsPop.SetActive(!_settingsPop.activeSelf);
            }
        }
    }
}
