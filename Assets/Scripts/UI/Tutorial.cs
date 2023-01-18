using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Button tutorialCanvas;
    [SerializeField] private Button backBtn;
    [SerializeField] private Button formulaBookBtn;
    [SerializeField] private GameObject bookTutorial;
    [SerializeField] private GameObject backBtnTutorial;
    [SerializeField] private GameObject formulaBookTutorial;
    [SerializeField] private GameObject trueAnswersTutorial;
    [SerializeField] private GameObject falseAnswersTutorial;
    [SerializeField] private GameObject resultsTutorial;
    [SerializeField] private GameObject bookCanvas;
    [SerializeField] private GameObject formulaTutorial;
    [SerializeField] private GameObject MainTable;
    [SerializeField] private Button workBook;
    [SerializeField] private Canvas trueAnswer;
    [SerializeField] private Canvas falseAnswer;
    [SerializeField] private Canvas result;
    [SerializeField] private Camera camera;

    void Start()
    {
        workBook.gameObject.GetComponent<Canvas>().sortingOrder = 2;
        workBook.onClick.AddListener(ShowTrueAnswerTutorial);
        bookTutorial.SetActive(true);
    }


    private void ShowTrueAnswerTutorial()
    {
        workBook.gameObject.GetComponent<Canvas>().sortingOrder = 0;
        trueAnswer.sortingOrder = 2;
        bookTutorial.SetActive(false);
        trueAnswersTutorial.SetActive(true);
        tutorialCanvas.onClick.AddListener(ShowFalseAnswerTutorial);
        workBook.onClick.RemoveListener(ShowTrueAnswerTutorial);
    }

    private void ShowFalseAnswerTutorial()
    {
        workBook.onClick.RemoveListener(ShowTrueAnswerTutorial);
        trueAnswer.sortingOrder = 1;
        falseAnswer.sortingOrder = 2;
        trueAnswersTutorial.SetActive(false);
        falseAnswersTutorial.SetActive(true);
        tutorialCanvas.onClick.AddListener(ShowResultTutorial);
    }

    private void ShowResultTutorial()
    {
        falseAnswer.sortingOrder = 1;
        result.sortingOrder = 2;
        falseAnswersTutorial.SetActive(false);
        resultsTutorial.SetActive(true);
        tutorialCanvas.onClick.AddListener(ShowToBackMenuTutorial);
    }

    private void ShowToBackMenuTutorial()
    {
        tutorialCanvas.onClick.RemoveAllListeners();
        result.sortingOrder = 1;
        backBtn.gameObject.GetComponent<Canvas>().sortingOrder = 2;
        resultsTutorial.SetActive(false);
        backBtnTutorial.SetActive(true);
        backBtn.onClick.AddListener(ShowFormulaBookTutorial);
    }

    private void ShowFormulaBookTutorial()
    {
        backBtn.onClick.RemoveListener(ShowFormulaBookTutorial);
        backBtnTutorial.SetActive(false);
        formulaBookTutorial.SetActive(true);
        formulaBookBtn.gameObject.GetComponent<Canvas>().sortingOrder = 1;
        formulaBookBtn.onClick.AddListener(ShowFormulaTutorial);
    }

    private void ShowFormulaTutorial()
    {
        formulaBookBtn.onClick.RemoveListener(ShowFormulaTutorial);
        formulaTutorial.SetActive(true);
        formulaBookTutorial.SetActive(false);
        formulaBookBtn.gameObject.GetComponent<Canvas>().sortingOrder = 0;
        tutorialCanvas.onClick.AddListener(FinishTutorial);
        trueAnswer.sortingOrder = 0;
        falseAnswer.sortingOrder = 0;
        result.sortingOrder = 0;
    }


    private void FinishTutorial()
    {
        camera.orthographic = false;
        MainTable.SetActive(true);
        bookCanvas.SetActive(false);
        formulaTutorial.SetActive(false);
        tutorialCanvas.gameObject.SetActive(false);
        workBook.gameObject.GetComponent<Canvas>().sortingOrder = 1;
        formulaBookBtn.gameObject.GetComponent<Canvas>().sortingOrder = 1;
        trueAnswer.sortingOrder = 1;
        falseAnswer.sortingOrder = 1;
        result.sortingOrder = 1;
    }
}