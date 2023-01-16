using UnityEngine;

public class OverGame : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("IsGameComplete",0) != 1)
            gameObject.SetActive(false);
        else
        {
            Cursor.visible = true;
            PlayerPrefs.SetInt("IsGameComplete", 2);
        }
    }
}
