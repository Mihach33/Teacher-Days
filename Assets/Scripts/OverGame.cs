using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverGame : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("IsGameComplete",0) == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
