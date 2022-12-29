using UI;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button continueBtn;
    [SerializeField] private ThirdPersonOrbitCamBasic cam;

    private bool _isPauseFreeze;

    private void Start()
    {
        _isPauseFreeze = false;
        pauseCanvas.SetActive(false);
        continueBtn.onClick.AddListener(() =>
            {
                // pauseCanvas.SetActive(false);
                // Time.timeScale = 1;
                // if (cam != null)
                // {
                //     cam.smooth = 10;
                //     cam.horizontalAimingSpeed = 6;
                //     cam.verticalAimingSpeed = 6;
                // }
                // _isPauseFreeze = false;
                SetPause();
            }
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
        if (_isPauseFreeze)
        {
            _isPauseFreeze = false;
            return 1;
        }

        _isPauseFreeze = true;
        return 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }

        Cursor.visible = _isPauseFreeze;
    }

    private void SetPause()
    {
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);
        Time.timeScale = (cam != null) ? GetIsPause() : GetIsPauseWithoutCamera();
    }
}