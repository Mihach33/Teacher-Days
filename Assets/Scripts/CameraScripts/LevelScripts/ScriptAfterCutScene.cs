using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ScriptAfterCutScene : MonoBehaviour
{
    private PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        director = gameObject.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing)
        {
            FindObjectOfType<SceneLoader>().LoadScene("PlayGroundScene");
            // SceneManager.LoadScene("PlayGroundScene");
        }
    }
}
