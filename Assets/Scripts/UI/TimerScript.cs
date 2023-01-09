using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class TimerScript : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    private float timeStart;
    private static bool timerIsOn;
    private int lvl;
    public int[] levels;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name.Equals("PlayGroundScene") ||
            SceneManager.GetActiveScene().name.Equals("PlayGroundSceneNoTutor"))
        {
            lvl = PlayerPrefs.GetInt("Level", 1);
            Debug.Log(lvl);
        }
        else
        {
            timeStart = 1000;
        }

        _textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        timerIsOn = true;
        if (SceneManager.GetActiveScene().name.Equals("PlayGroundScene") ||
            SceneManager.GetActiveScene().name.Equals("PlayGroundSceneNoTutor"))
        {
            switch (lvl)
            {
                case 1:
                    timeStart = levels[0];
                    break;
                case 2:
                    timeStart = levels[1];
                    break;
                case 3:
                    timeStart = levels[2];
                    break;
                case 4:
                    timeStart = levels[3];
                    break;
            }
        }
    }

    public static void SetTimer(bool timer)
    {
        timerIsOn = timer;
    }

    private void Update()
    {
        if (timerIsOn)
        {
            if (timeStart < 0)
            {
                Debug.Log("game over");
                enabled = false;
                return;
            }

            timeStart -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeStart / 60);
            float seconds = Mathf.FloorToInt(timeStart % 60);
            _textMeshProUGUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}