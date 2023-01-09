using UI;
using UnityEngine;
using UnityEngine.Playables;

public class ScriptAfterCutScene : MonoBehaviour
{
    private PlayableDirector director;
    void Start()
    {
        director = gameObject.GetComponent<PlayableDirector>();
    }

    void Update()
    {
        if (director.state != PlayState.Playing)
        {
            FindObjectOfType<SceneLoader>().LoadScene("PlayGroundScene");
        }
    }
}
