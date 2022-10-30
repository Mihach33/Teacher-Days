using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class CheckCircleOverlap : MonoBehaviour
    {
        [SerializeField] private OnOverlap _onOverlap;
        [SerializeField] private string[] _tags;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _radius = 1f;
        private readonly Collider[] _interactionResult = new Collider[5];
        
        public void Check()
        {
            var size = Physics.OverlapSphereNonAlloc(transform.position,
                _radius, _interactionResult, _layerMask);
            for (var i = 0; i < size; i++){
                var overlapResult = _interactionResult[i];
                var isInTags =_tags.Any(tag => overlapResult.CompareTag(tag));
                if (isInTags)
                {
                    _onOverlap?.Invoke(overlapResult.gameObject);
                }
            }
        }
        
        [Serializable]
        public class OnOverlap : UnityEvent<GameObject>
        {
            
        }
    }
}