using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Puck : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    public bool Moving {  get; private set; }

    private Vector3 moveDirection;
    private Vector3 targetPosition;
    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        
        if (MathF.Abs(transform.position.x) < MathF.Abs(targetPosition.x)-0.5 && moveDirection.x/Vector3.right.x>0)
        {
            transform.position += moveDirection * speed * Time.fixedDeltaTime;
        }
        else if (MathF.Abs(transform.position.x) > MathF.Abs(targetPosition.x)+1 && moveDirection.x / Vector3.right.x < 0)
        {
            transform.position += moveDirection * speed * Time.fixedDeltaTime;
        }
        else if (MathF.Abs(transform.position.z) < MathF.Abs(targetPosition.z)-0.5 && moveDirection.z / Vector3.right.z > 0 && Moving)
        {
            transform.position += moveDirection * speed * Time.fixedDeltaTime;
        }
        else if (MathF.Abs(transform.position.z) > MathF.Abs(targetPosition.z)+1 && moveDirection.z / Vector3.right.z < 0 && Moving)
        {
            transform.position += moveDirection * speed * Time.fixedDeltaTime;
        }
        else 
        {
            Moving = false;
            targetPosition = Vector3.zero;
            moveDirection = Vector3.zero;
            transform.position = new Vector3((int)transform.position.x, transform.position.y ,(int)transform.position.z);
        }
    }

    private void OnEnable()
    {
        PlayerInput.OnChoiceDirection += Launch;
    }

    private void OnDisable()
    {
        PlayerInput.OnChoiceDirection -= Launch;
    }

    public void Launch(Vector3 direction)
    {
        var obstaclePosition = RaycastCheck.ObstacleTo(transform.position, direction);

        if (obstaclePosition != Vector3.zero && Moving==false)
        {
            moveDirection = direction;
            targetPosition = obstaclePosition;

            if (targetPosition != transform.position)
            {
                Moving = true;
            }

            obstaclePosition = Vector3.zero;
        }
    }
}
