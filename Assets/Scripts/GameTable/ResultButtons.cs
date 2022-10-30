using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Script.GameTable
{
    public class ResultButtons : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private Button continueButton;

        private void Start()
        {
            restartButton.onClick.AddListener(() => { FindObjectOfType<SceneLoader>().LoadScene("PlayGroundScene"); });
            continueButton.onClick.AddListener(() =>
            {
                FindObjectOfType<SceneLoader>().LoadScene("SchoolNoCutScene");
            });
            menuButton.onClick.AddListener(() => { FindObjectOfType<SceneLoader>().LoadScene("MainMenu"); });
        }
    }
}