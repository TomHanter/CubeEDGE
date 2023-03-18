using DefaultNamespace.Inputs;
using UnityEngine;

[RequireComponent(typeof(CubeController))]
public class PlayerKeyboardInput : PlayerInputBase
{
    protected override void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _cubeController.Move(-Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _cubeController.Move(-Vector3.right);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _cubeController.Move(-Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _cubeController.Move(-Vector3.back);
        }
    }
}