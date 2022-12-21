using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    Vector3 offset;
    [SerializeField] public Transform _rectTransform;
    public void GetOffset()
        {
            offset = _rectTransform.position - Input.mousePosition;
        }
        public void MoveObject()
        {
            if (Input.mousePosition.x + offset.x > -800)
            {
                _rectTransform.position = Input.mousePosition + offset;
            }
            
        }
}
