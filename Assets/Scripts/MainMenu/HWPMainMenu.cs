using UI;
using UnityEngine;
using UnityEngine.UI;

public class HWPMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPop;
    [SerializeField] private Button buttonStart;
    [SerializeField] private Button continueBtn;
    [SerializeField] private Button buttonExit;
    private string levelKey = "Level";
    private string gameCompleteKey = "IsGameComplete";

    void Start()
    {
        settingsPop.SetActive(false);
        buttonExit.onClick.AddListener(() => { Application.Quit(); });
        buttonStart.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteKey(levelKey);
            PlayerPrefs.DeleteKey(gameCompleteKey);
            FindObjectOfType<SceneLoader>().LoadScene("School");
        });
        continueBtn.onClick.AddListener(() => { FindObjectOfType<SceneLoader>().LoadScene("SchoolNoCutScene"); });
        if (!PlayerPrefs.HasKey(levelKey))
        {
            continueBtn.gameObject.SetActive(false);
        }
    }
}