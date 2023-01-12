using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private string[] text;
    [SerializeField] private TextMeshProUGUI dialogue;
    [SerializeField] private float delay;
    [SerializeField] private float delay1;
    private string currentString = "";
    private static bool isDialogueFinish;

    public void StartDialogueCoroutine()
    {
        gameObject.SetActive(true);
        StartCoroutine(writeText(text));
    }

    public void setText(string[] text)
    {
        this.text = text;
    }


    private IEnumerator writeText(string[] text)
    {
        dialogue.text = "";
        yield return new WaitForSeconds(1);
        foreach (var t in text)
        {
            for (int j = 0; j < t.Length; j++)
            {
                dialogue.text = t.Substring(0, j);
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(delay1);
        }

        isDialogueFinish = true;
        Invoke("Finish", 1f);
    }

    private void Finish()
    {
        gameObject.SetActive(false);
    }

    public static bool GetIsDialogueFinish()
    {
        return isDialogueFinish;
    }

    public static void SetIsDialogueFinish(bool isFinish)
    {
        isDialogueFinish = isFinish;
    }
}