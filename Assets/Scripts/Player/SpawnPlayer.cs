using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private Vector3 pos;
    private Quaternion rotation;
    void Start()
    {
        if (PlayerPrefs.HasKey("x") && PlayerPrefs.HasKey("y") && PlayerPrefs.HasKey("z") )
        {
            pos = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            rotation = new Quaternion(PlayerPrefs.GetFloat("rotationX",0), PlayerPrefs.GetFloat("rotationY",0),PlayerPrefs.GetFloat("rotationZ",0),PlayerPrefs.GetFloat("rotationW",0));
            gameObject.transform.position = pos;
            gameObject.transform.rotation = rotation;
            PlayerPrefs.DeleteKey("x");
            PlayerPrefs.DeleteKey("y");
            PlayerPrefs.DeleteKey("z");
            PlayerPrefs.DeleteKey("rotationX");
            PlayerPrefs.DeleteKey("rotationY");
            PlayerPrefs.DeleteKey("rotationZ");
            PlayerPrefs.DeleteKey("rotationW");
        }
    }
}
