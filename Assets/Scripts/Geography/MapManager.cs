using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    Vector3 offset;
    [SerializeField] public Transform _rectTransform;
    public int limitx;
    public int limitx2;
    public int limity1;
    public int limity2;
    public void GetOffset()
        {
            offset = _rectTransform.position - Input.mousePosition;
        }
        public void MoveObject()
        {
            if (Input.mousePosition.x + offset.x > limitx && Input.mousePosition.y + offset.y > limity1 && Input.mousePosition.y + offset.y < limity2 && Input.mousePosition.x + offset.x < limitx2)
            {
                _rectTransform.position = Input.mousePosition + offset;
            }
            
        }
}
