using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

namespace Components
{
    public class SavePlayerPosition : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private Vector3 playerPosition;
        public void LoadScene()
        {
            playerPosition = player.transform.position;
            PlayerPrefs.SetFloat("x",playerPosition.x);
            PlayerPrefs.SetFloat("rotationX",player.transform.rotation.x);
            PlayerPrefs.SetFloat("rotationY",player.transform.rotation.y);
            PlayerPrefs.SetFloat("rotationZ",player.transform.rotation.z);
            PlayerPrefs.SetFloat("rotationW",player.transform.rotation.w);
            PlayerPrefs.SetFloat("y",playerPosition.y);
            PlayerPrefs.SetFloat("z",playerPosition.z);
        }
    }
}