using UnityEngine;

namespace DefaultNamespace.Inputs
{
    [RequireComponent(typeof(CubeController))]
    public abstract class PlayerInputBase : MonoBehaviour
    {
        protected CubeController _cubeController;

        private void Start()
        {
            _cubeController = GetComponent<CubeController>();
        }
        
        private void Update()
        {
            ProcessInput();
        }

        protected abstract void ProcessInput();
    }
}