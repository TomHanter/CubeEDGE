using System;
using UnityEngine;

namespace DefaultNamespace
{

    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour
                              where T : SingletonMonoBehaviour<T>
    {
        private static T _instance;
        //Singltne pattern
        public static T Instance => _instance;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
                return;
            }
            
            _instance = (T)this;
        }
    }
    
    public class GameStateManager : SingletonMonoBehaviour<GameStateManager>
    {
        private bool _isDead = false;
        private GameObject _player;

        private void Start()
        {
            _player = FindObjectOfType<PlayerKeyboardInput>().gameObject;
        }

        public void Die()
        {
            Destroy(_player); 
            _isDead = true;
        }
    }
}