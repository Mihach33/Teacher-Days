using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class WaitAnimation : MonoBehaviour
{
    [SerializeField]private string name;
    [SerializeField] private SceneLoader _sceneLoader;
  
    
    
    void Update()
    {
        if (DialogueScript.GetIsDialogueFinish())
        {
            DialogueScript.SetIsDialogueFinish(false);
            _sceneLoader.LoadScene(name);
           
        } 
    }
}
