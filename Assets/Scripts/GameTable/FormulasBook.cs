using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameTable
{
    public class FormulasBook : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Button[] _firstStack;
        [SerializeField] private Button[] _secondStack;
        [SerializeField] private Button _goToNextFormulas;
        [SerializeField] private Button _goToPreviousFormulas;
        [SerializeField] private AnimationClip slideForward;
        [SerializeField] private AnimationClip slideBack;
        [SerializeField] private AnimationState slideBack1;

        private void Start()
        {
            _goToPreviousFormulas.enabled = false;
            _goToNextFormulas.enabled = true;
            _goToNextFormulas.onClick.AddListener(() => StartCoroutine(ShowNextFormulas()));
            _goToPreviousFormulas.onClick.AddListener(() => StartCoroutine(ShowPreviousFormulas()));
        }

        private IEnumerator ShowNextFormulas()
        {
            foreach (var button in _firstStack)
            {
                button.gameObject.SetActive(!button.gameObject.activeSelf);
            }
            _goToNextFormulas.enabled = false;
            _goToPreviousFormulas.enabled = true;

            _animator.Play("SlideForward");
            while (_animator.GetCurrentAnimatorStateInfo(0).IsName("SlideForward"))
            {
                yield return null;
            }
            
            while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < 0.99f)
            {
                yield return null;
            }
            _animator.Play("WorkBookIdle");
            foreach (var button in _secondStack)
            {
                button.gameObject.SetActive(!button.gameObject.activeSelf);
            }
            
        }

        private IEnumerator ShowPreviousFormulas()
        {
            foreach (var button in _secondStack)
            {
                button.gameObject.SetActive(!button.gameObject.activeSelf);
            }
            _goToPreviousFormulas.enabled = false;
            _goToNextFormulas.enabled = true;
            
            _animator.Play("SlideBack");
            while (_animator.GetCurrentAnimatorStateInfo(0).IsName("SlideBack"))
            {
                yield return null;
            }
            
            while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < 0.99f)
            {
                yield return null;
            }
            _animator.Play("WorkBookIdle");
            foreach (var button in _firstStack)
            {
                button.gameObject.SetActive(!button.gameObject.activeSelf);
            }
        }
    }
}