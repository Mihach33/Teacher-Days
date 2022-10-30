using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    public AudioSource music;
    private void Update()
    {
        music.volume = gameObject.GetComponent<Slider>().value;
    }
}
