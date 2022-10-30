using UI;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame: MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button continueBtn;

    private bool isPauseFreeze;
    private void Start()
    {
        isPauseFreeze = false;
        pauseCanvas.SetActive(false);
        continueBtn.onClick.AddListener(() =>
            {
                pauseCanvas.SetActive(false);
                TimerScript.SetTimer(true);
            }
        );
        exitBtn.onClick.AddListener(()=>FindObjectOfType<SceneLoader>().LoadScene("MainMenu"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.SetActive(!pauseCanvas.activeSelf);
        }
    }
    
}