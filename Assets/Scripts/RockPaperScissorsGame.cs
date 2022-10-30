using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class RockPaperScissorsGame : MonoBehaviour
    {
        [SerializeField] private Button[] _playerButtons;
        [SerializeField] private Button _result;
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private Animator _computerAnimator;

        private string[] states = {"Rock", "Paper", "Scissors"};

        Dictionary<string, string> beat_states = new Dictionary<string, string>()
        {
            {"Rock", "Scissors"},
            {"Paper", "Rock"},
            {"Scissors", "Paper"}
        };

        private void Start()
        {
            Cursor.visible = true;
            foreach (var button in _playerButtons)
            {
               button.onClick.AddListener(() =>
               {
                   StartCoroutine(CalculateFight(button.GetComponentInChildren<TextMeshProUGUI>().text));
               });
            }
        }

        private IEnumerator CalculateFight(string userInput)
        {
            _result.GetComponentInChildren<TextMeshProUGUI>().text = "Playing...";
            foreach (var playerButton in _playerButtons)
            {
                playerButton.enabled = false;
            }
            var computerInput = states[Random.Range(0, states.Length)];
            
            SetState(_playerAnimator, userInput);
            SetState(_computerAnimator, computerInput);
            
            yield return new WaitForSeconds(2f);
            
            foreach (var playerButton in _playerButtons)
            {
                playerButton.enabled = true;
            }

            var userWinCase = beat_states[userInput];
            var computerWinCase = beat_states[computerInput];
            if (userWinCase.Equals(computerInput))
            {
                _result.GetComponentInChildren<TextMeshProUGUI>().text = "You Win";
                yield break;
            }

            if (computerWinCase.Equals(userInput))
            {
                _result.GetComponentInChildren<TextMeshProUGUI>().text = "You Lose";
                yield break;
            }

            _result.GetComponentInChildren<TextMeshProUGUI>().text = "Draw";
        }
        
        private void SetState(Animator animator, string state)
        {
            switch (state)
            {
                case "Rock":
                    animator.SetBool("Rock", true);
                    animator.SetBool("Paper", false);
                    animator.SetBool("Scissors", false);
                    break;
                case "Paper":
                    animator.SetBool("Paper", true);
                    animator.SetBool("Rock", false);
                    animator.SetBool("Scissors", false);
                    break;
                case "Scissors":
                    animator.SetBool("Scissors", true);
                    animator.SetBool("Rock", false);
                    animator.SetBool("Paper", false);
                    break;
            }
            animator.SetTrigger("handAnimation");
        }
    }
}