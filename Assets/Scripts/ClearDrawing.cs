using UnityEngine;
using UnityEngine.UI;

public class ClearDrawing : MonoBehaviour
{
    private Button _clearButton;
    [SerializeField] GameObject parent;
    private LineRenderer[] prefabs;
    private void Start()
    {
        _clearButton = gameObject.GetComponent<Button>();
        _clearButton.onClick.AddListener(() =>
        {
            prefabs = parent.GetComponentsInChildren<LineRenderer>();
            foreach (var prefab in prefabs)
            {
                Destroy(prefab);
            }
        });
    }
    
}
