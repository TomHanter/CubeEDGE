using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace.EventObjects
{
    public class FallingPlatform : MovingPlatform
    {
        [SerializeField] private float _distance = 10f;
        [SerializeField] private float _duraction = 1f;
        [SerializeField] private float _delay = 0.5f;
        
        public override void Move()
        {
            transform.DOMove(Vector3.down * _distance, _duraction)
                .OnComplete(OnComplete)
                .SetDelay(_delay);
        }

        private void OnComplete()
        {
            Destroy(gameObject);
        }
    }
}