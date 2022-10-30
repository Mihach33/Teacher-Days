using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseOpen : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        private Button _pauseButton;

        private void Awake()
        {
            _pauseButton = GetComponent<Button>();
            _pauseButton.onClick.AddListener(OpenMenu);
        }

        private void OpenMenu()
        {
            TimerScript.SetTimer(false);
            _pauseMenu.SetActive(true);
        }
    }
}