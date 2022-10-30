using System;
using UnityEngine;
using Random = System.Random;

namespace UI
{
    public class ShowRandomComment : MonoBehaviour
    {
        [SerializeField] private string[] comments;
        [SerializeField] private DialogueScript dialogueScript;

        public void Comment()
        {
            Random random = new Random();
            string randomComment = comments[random.Next(0, comments.Length)];
            dialogueScript.setText(new []{randomComment});
            dialogueScript.StartDialogueCoroutine();
        }
    }
}