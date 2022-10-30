using UI;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            Cursor.visible = false;
            FindObjectOfType<SceneLoader>().LoadScene("SchoolNoCutScene");
        }); 
    }
    
}
