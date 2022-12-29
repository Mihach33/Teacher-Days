using System;
using UnityEngine;

namespace UI
{
    public class CursorView : MonoBehaviour
    {
        [SerializeField] private bool isVisible;
        
        private void Start()
        {
            Cursor.visible = isVisible;
        }
    }
}