using UnityEngine;

namespace DefaultNamespace.Inputs
{
    public class PlayerJoystickInput : PlayerInputBase
    {
        [SerializeField] private JoystickTouchZone _joystick;

        protected override void ProcessInput()
        {
            var currentInput = _joystick.CurrentDirection;

            if (currentInput == Vector2.zero) return;

            currentInput = Clamp(currentInput);

            var currentInputV3 = new Vector3(
                currentInput.x,
                0f,
                currentInput.y
            );
            _cubeController.Move(currentInputV3);
        }

        private Vector2 Clamp(Vector2 currentInput)
        {
            if (Mathf.Abs(currentInput.x) > Mathf.Abs(currentInput.y))
            {
                return new Vector2(Mathf.Round(currentInput.x), 0f);
            }
            else
            {
                return new Vector2(0f, Mathf.Round(currentInput.y));
            }
        }
    }
}