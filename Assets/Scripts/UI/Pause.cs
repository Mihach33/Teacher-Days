using Components;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button continueBtn;
    [SerializeField] private ThirdPersonOrbitCamBasic cam;
    [SerializeField] private BoardInteractComponent board;
    [SerializeField] private GameObject gameOverCanvas;


    private bool _isPauseFreeze;

    private void Start()
    {
        _isPauseFreeze = false;
        pauseCanvas.SetActive(false);
        continueBtn.onClick.AddListener(() => { SetPause(); }
        );
        exitBtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            FindObjectOfType<SceneLoader>().LoadScene("MainMenu");
        });
    }

    private int GetIsPause()
    {
        if (_isPauseFreeze)
        {
            cam.smooth = 10;
            cam.horizontalAimingSpeed = 6;
            cam.verticalAimingSpeed = 6;
            _isPauseFreeze = false;
            return 1;
        }

        cam.smooth = 0;
        cam.horizontalAimingSpeed = 0;
        cam.verticalAimingSpeed = 0;
        _isPauseFreeze = true;
        return 0;
    }

    private int GetIsPauseWithoutCamera()
    {
        if (pauseCanvas.activeSelf)
        {
            return 0;
        }

        return 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }

        if (gameOverCanvas != null && gameOverCanvas.activeSelf)
        {
            Cursor.visible = true;
        }
        else if (cam != null && !board.canDraw)
        {
            Cursor.visible = _isPauseFreeze;
        }
    }

    private void SetPause()
    {
        if (board == null)
        {
            pauseCanvas.SetActive(!pauseCanvas.activeSelf);
            Time.timeScale = (cam != null) ? GetIsPause() : GetIsPauseWithoutCamera();
        }
        else if (!board.canDraw)
        {
            pauseCanvas.SetActive(!pauseCanvas.activeSelf);
            Time.timeScale = (cam != null) ? GetIsPause() : GetIsPauseWithoutCamera();
        }
    }
}