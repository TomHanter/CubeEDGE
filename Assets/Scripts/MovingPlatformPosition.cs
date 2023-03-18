using System;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class MovingPlatformPosition : MonoBehaviour
    {
        [SerializeField] private Transform _pos1;
        [SerializeField] private Transform _pos2;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private Ease _ease = Ease.Linear;

        private Transform _currentPos;
        private bool _isMoving = false;

        private void Start()
        {
            _currentPos = _pos1;
            transform.position = _pos1.position;
        }

        public void Move()
        {
            if (_isMoving) return;
            _isMoving = true;

            if (_currentPos == _pos1)
            {
                MoveToPos(_pos2);
            }
            else
            {
                MoveToPos(_pos1);
            }
        }

        private void MoveToPos(Transform targetPos)
        {
            var distance = Vector3.Distance(transform.position, targetPos.position);
            var duration = distance / _speed;

            _currentPos = targetPos;
            transform.DOMove(_pos1.position, duration)
                .SetEase(_ease)
                .OnComplete(OnComplete);
        }

        private void OnComplete()
        {
            _isMoving = false;
        }
    }
}