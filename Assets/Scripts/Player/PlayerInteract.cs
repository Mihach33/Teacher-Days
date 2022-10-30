using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private CheckCircleOverlap _interactionCheck;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        _interactionCheck.Check();
    }
    
}
