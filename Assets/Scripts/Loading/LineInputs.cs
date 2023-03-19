using System;
using UnityEngine;

namespace Loading
{
    public class LineInputs : MonoBehaviour
    {
        public static Action<PowerUps> onGetPowerUps;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                GetPowerUp(PowerUps.LoadingLine);
                return;
            }
        }
        private void GetPowerUp(PowerUps callingPowerUp)
        {
            if (onGetPowerUps != null)
                onGetPowerUps(callingPowerUp);
        }
    }
}