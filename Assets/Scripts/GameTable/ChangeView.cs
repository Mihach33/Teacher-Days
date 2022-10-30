using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeView : MonoBehaviour
{
    private Camera _camera;
    
    [SerializeField] private GameObject mainTable;
    [SerializeField] private Button _toWorkButton;
    [SerializeField] private Button _toBookButton;
    [SerializeField] private Button _fromWorkButton;
    [SerializeField] private Button _fromBookButton;
    [SerializeField] private GameObject workBookCanvas;
    [SerializeField] private GameObject bookCanvas;
    

    void Start()
    {
        mainTable.SetActive(true);
        workBookCanvas.SetActive(false);
        _camera = GetComponent<Camera>();
        _camera.orthographic = false;
        _toWorkButton.onClick.AddListener(ChangeWorkBookView);
        _toBookButton.onClick.AddListener(ChangeBookView);
        _fromWorkButton.onClick.AddListener(ChangeWorkBookView);
        _fromBookButton.onClick.AddListener(ChangeBookView);
    }

    void ChangeWorkBookView()
    {
        mainTable.SetActive(!mainTable.activeSelf);
        workBookCanvas.SetActive(!workBookCanvas.activeSelf);
        _camera.orthographic = !_camera.orthographic;
    }
    void ChangeBookView()
    {
        mainTable.SetActive(!mainTable.activeSelf);
        bookCanvas.SetActive(!bookCanvas.activeSelf);
        _camera.orthographic = !_camera.orthographic;
    }

}
