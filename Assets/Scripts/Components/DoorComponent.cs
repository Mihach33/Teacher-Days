using UnityEngine;

namespace Components
{
    public class DoorComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _state;
        [SerializeField] private string _animationKey;

        public void MoveDoor()
        {
            _state = !_state;
            _animator.SetBool(_animationKey, _state);
        }
    }
}