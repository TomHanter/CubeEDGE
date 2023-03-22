using System;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class PickUpManager : SingletonMonoBehaviour<PickUpManager>
    {
        [SerializeField] private int _currentPlayerAmout;
        [SerializeField] private AnimaterdScoreDispaly _scoreDispaly;

        private void Start()
        {
            _scoreDispaly.Set(_currentPlayerAmout);
        }

        public void AddMoney(int amout)
        {
            _scoreDispaly.Animate(_currentPlayerAmout, _currentPlayerAmout + amout);

            _currentPlayerAmout += amout;
        }
    }
}