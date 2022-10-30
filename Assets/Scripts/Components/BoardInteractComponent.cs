using System;
using UnityEngine;

namespace Components
{
    public class BoardInteractComponent : MonoBehaviour
    {  
        [SerializeField] private GameObject slider;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Camera _boardCamera;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _clearBtn;
        public bool canDraw;

        private void Start()
        {
            _clearBtn.SetActive(false);
            _boardCamera.enabled = false;
            canDraw = false;
        }

        private void Update()
        {
            if (canDraw && Input.GetKey(KeyCode.Escape))
            {
                ChangeView();
            }
        }

        public void ChangeView()
        {
             Cursor.visible = !Cursor.visible;
             slider.SetActive(!slider.activeSelf);
            _clearBtn.SetActive(!_clearBtn.activeSelf);
            _boardCamera.enabled = !_boardCamera.enabled;
            _mainCamera.enabled = !_mainCamera.enabled;
             canDraw = !canDraw;
            _player.SetActive(!_player.activeSelf);
        }
    }
}