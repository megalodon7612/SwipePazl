using System.Collections;
using System.Collections.Generic;
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
        if (targetPosition != transform.position)
        {
            transform.position += moveDirection * speed * Time.fixedDeltaTime;
        }
        else 
        {
            Moving = false;
            targetPosition = Vector3.zero;
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

        if (obstaclePosition != Vector3.zero)
        {
            moveDirection = direction;
            targetPosition = obstaclePosition;

            if (targetPosition != transform.position)
            {
                Moving = true;
            }

            targetPosition = Vector3.zero;
        }
    }
}
