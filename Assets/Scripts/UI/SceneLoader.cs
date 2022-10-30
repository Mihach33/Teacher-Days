using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private float _animationTime = 1f;
        [SerializeField] private string _sceneName;

        public void LoadScene(string name)
        {
            _sceneName = name;
            StartCoroutine(LoadSceneWithAnimation());
        }

        private IEnumerator LoadSceneWithAnimation()
        {
            animator.SetTrigger("LoadOut");

            yield return new WaitForSeconds(_animationTime);

            SceneManager.LoadScene(_sceneName);
        }
    }
}
