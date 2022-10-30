using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PaperToss
{
    public class ChangeScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int score = 0;

        private void Start()
        {
            _scoreText.text = $"Score: {score}";
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Toss"))
            {
                score++;
                _scoreText.text = $"Score: {score}";
            }
        }
    }
}