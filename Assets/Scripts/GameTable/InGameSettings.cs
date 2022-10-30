using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Script.GameTable
{
    public class InGameSettings : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPop;
        [SerializeField] private GameObject _pausePop;
      
        [SerializeField] private Button _settingsOpenButton;
        [SerializeField] private Button _backToMainButton;

        void Start()
        {
            _settingsPop.SetActive(false);
            _settingsOpenButton.onClick.AddListener(TurnButtons);
            _backToMainButton.onClick.AddListener(TurnButtons);
        }

        private void TurnButtons()
        {
            _settingsPop.SetActive(!_settingsPop.activeSelf);
        }

      
        
    }
}