using System.Linq;
using UnityEngine;

namespace UI
{
    public class UIVisible : MonoBehaviour
    {
        [SerializeField] private GameObject _UITools;
        [SerializeField] private GameObject[] _canvases;
        private bool _isVisible;

        private void Start()
        {
            _UITools.SetActive(_isVisible);
        }

        private void Update()
        {
            _isVisible = _canvases.Any(x => x.activeSelf);
            _UITools.SetActive(_isVisible);
        }
    }
}