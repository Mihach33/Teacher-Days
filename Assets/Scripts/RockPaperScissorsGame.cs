using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace
{
    public class RockPaperScissorsGame : MonoBehaviour
    {
        [SerializeField] private Button[] _playerButtons;
        [SerializeField] private Button _result;
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private Animator _computerAnimator;
        [SerializeField] private AudioSource _audioSource;

        private static string[] states = { "Rock", "Paper", "Scissors" };
        static int[,] transitionMatrix = new int[states.Length, states.Length];
        static int[] moveFrequency = new int[states.Length];
        static Random random = new Random();

        private void Start()
        {
            foreach (var button in _playerButtons)
            {
                button.onClick.AddListener(() =>
                {
                    _audioSource.Play();
                    StartCoroutine(CalculateFight(button.GetComponentInChildren<TextMeshProUGUI>().text));
                });
            }
        }
        
        static void UpdateTransitionMatrix(string move1, string move2)
        {
            int index1 = Array.IndexOf(states, move1);
            int index2 = Array.IndexOf(states, move2);
            transitionMatrix[index1, index2]++;
        }
        
        static int GetOutcome(string move1, string move2)
        {
            int index1 = Array.IndexOf(states, move1);
            int index2 = Array.IndexOf(states, move2);
            int[][] transitionMatrix = new[] { new int[] { 0, 1, -1 }, new int[] { -1, 0, 1 }, new int[] { 1, -1, 0 } };
            return transitionMatrix[index1][index2];
        }

        static string ChooseMove(int[] moveFrequency)
        {
            int[] probabilities = new int[states.Length];
            int total = 0;
            for (int i = 0; i < states.Length; i++)
            {
                for (int j = 0; j < states.Length; j++)
                    total += transitionMatrix[i, j];
                if (total == 0)
                    probabilities[i] = 0;
                else
                    probabilities[i] = transitionMatrix[i, i] / total;
            }
        
            int randomNumber = random.Next(100);
            int cumulativeProbability = 0;
            for (int i = 0; i < states.Length; i++)
            {
                cumulativeProbability += probabilities[i] * 100;
                if (randomNumber <= cumulativeProbability)
                    return states[i];
            }
            return states[random.Next(states.Length)];
        }
        

        private IEnumerator CalculateFight(string userInput)
        {
            _result.GetComponentInChildren<TextMeshProUGUI>().text = "Playing...";
            foreach (var playerButton in _playerButtons)
            {
                playerButton.enabled = false;
            }

            var computerInput = ChooseMove(moveFrequency);
            int outcome = GetOutcome(userInput, computerInput);
            
            moveFrequency[Array.IndexOf(states, userInput)]++;
            UpdateTransitionMatrix(userInput, computerInput);
            foreach (var k in transitionMatrix)
            {
                Debug.Log(k);
            }

            SetState(_playerAnimator, userInput);
            SetState(_computerAnimator, computerInput);

            yield return new WaitForSeconds(2f);
            _audioSource.Stop();
            foreach (var playerButton in _playerButtons)
            {
                playerButton.enabled = true;
            }

            if (outcome == 1)
            {
                _result.GetComponentInChildren<TextMeshProUGUI>().text = "You Win";
                yield break;
            }

            if (outcome == -1)
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