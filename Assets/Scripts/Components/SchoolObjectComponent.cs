using UnityEngine;

namespace Components
{
    public class SchoolObjectComponent: MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _animationKey;

        public void PlayAnimation()
        {
            _animator.SetTrigger(_animationKey);
        }
    }
}