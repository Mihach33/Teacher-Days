using System.Collections.Generic;
using Components;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
    private List<Vector3> linePoints;
    private float timer;
    public float timeDelay;
    private GameObject newLine;
    private LineRenderer drawLine;
    private Camera _camera;
    private Vector3 _distance;
    [SerializeField] private Material _color;
    [SerializeField] private GameObject parent;
    [SerializeField] private Slider width;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private BoardInteractComponent _boardInteractComponent;

    private void Start()
    {
        _camera = gameObject.GetComponentInChildren<Camera>();
        width.gameObject.SetActive(false);
        linePoints = new List<Vector3>();
        timer = timeDelay;
      
    }

    private void Update()
    {
        if (!_boardInteractComponent.canDraw) return;
        
        var mousePos = GetMousePosition();
        if (mousePos == Vector3.zero) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            newLine = new GameObject();
            newLine.transform.parent = parent.transform;
            drawLine = newLine.AddComponent<LineRenderer>();
            drawLine.material = _color;
            drawLine.startWidth = width.value;
            drawLine.endWidth = width.value;
           
        }
        if (Input.GetMouseButton(0))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                linePoints.Add(mousePos);
                drawLine.positionCount = linePoints.Count;
                drawLine.SetPositions(linePoints.ToArray());
                timer = timeDelay;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            linePoints.Clear();
        }
    }

    Vector3 GetMousePosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50f, _mask))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

   
}