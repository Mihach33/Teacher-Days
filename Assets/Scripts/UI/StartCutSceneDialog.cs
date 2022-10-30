using UI;
using UnityEngine;

public class StartCutSceneDialog : MonoBehaviour
{
    [SerializeField] private DialogueScript dialogueScript;
    [SerializeField] private SceneLoader sceneLoader;
    void Start()
    {
        dialogueScript.StartDialogueCoroutine();
    }

    void Update()
    {
        if (DialogueScript.GetIsDialogueFinish())
        {
            sceneLoader.LoadScene("PlayGroundSceneNoTutor");
        }
    }
}
