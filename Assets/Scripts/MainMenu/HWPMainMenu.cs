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

    void Start()
    {
        settingsPop.SetActive(false);
        buttonExit.onClick.AddListener(() => { Application.Quit(); });
        buttonStart.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt(levelKey, 0);
            FindObjectOfType<SceneLoader>().LoadScene("School");
        });
        continueBtn.onClick.AddListener(() => { FindObjectOfType<SceneLoader>().LoadScene("SchoolNoCutScene"); });
        if (!PlayerPrefs.HasKey(levelKey))
        {
            continueBtn.gameObject.SetActive(false);
        }
    }
}