using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 5f;
    private Vector3 _pivotPoint;
    private Vector3 _axis;
    private bool _isMoving;
    private Rigidbody _rigidbody;
    private bool _hadWallOnPreviousStep;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void Move(Vector3 direction)
    {
        if (_isMoving) return;
        
        var isGrounded = BlockChecker.CheckIsGrounded(transform.position);
        if (!(isGrounded || _hadWallOnPreviousStep))
        {
            return;
        }

        _hadWallOnPreviousStep = false;
        
        var verticalComponent = Vector3.down;
        var hasWall = BlockChecker.HasWallInDirection(transform.position,direction);
        if (hasWall)
        {
            verticalComponent = Vector3.up;
            _hadWallOnPreviousStep = true;
        }
        
        _pivotPoint = (direction / 2f) + (verticalComponent / 2f ) + transform.position;
        _axis = Vector3.Cross(Vector3.up, direction);

        StartCoroutine(Roll(_pivotPoint, _axis));
    }

    private IEnumerator Roll(Vector3 pivot, Vector3 axis)
    {
        _isMoving = true;
        _rigidbody.isKinematic = true;

        for (int i = 0; i < 90 /_rollSpeed; i++)
        {
            transform.RotateAround(pivot, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        _rigidbody.isKinematic = false;
        _isMoving = false;

        BlockChecker.SnapPositionToInteger(transform);
    }
}
