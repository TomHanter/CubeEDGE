using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] private int _bonusAmout = 200;
        [SerializeField] private string _playerTag = "Player";

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                Pick();
            }
        }

        private void Pick()
        {
            PickUpManager.Instance.AddMoney(_bonusAmout);
            CoinAnimationManager.Instance.Animate(_bonusAmout, transform.position);
            Destroy(gameObject);
        }
    }
}