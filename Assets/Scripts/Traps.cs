using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Traps : MonoBehaviour
{
    public UnityEvent OnTrapActivated;
    public UnityEvent OnTrapDeactivated;

    public bool IsActivated = false;

    [SerializeField] private bool singleActivated = true;
    [SerializeField] private float serchRadius;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] Transform DetectedPoint;
    [SerializeField] Renderer trapRenderer;
    [SerializeField] Color activatiodColor;
    [SerializeField] Color detectedColor;

    private void Awake()
    {
        if(trapRenderer != null)
        {
            if (IsActivated == false)
            {
                trapRenderer.material.color = detectedColor;
            }
            else
            {
                trapRenderer.material.color = activatiodColor;
            }
        }
        if (IsActivated == true )
        {
            OnTrapActivated?.Invoke();
        }
        if (DetectedPoint == null)
        {
            DetectedPoint = transform;
        }
    }

    private void FixedUpdate()
    {
        Collider[] targetColiders = Physics.OverlapSphere(DetectedPoint.position, serchRadius, targetMask);
        if (targetColiders.Length > 0)
        {
            if (IsActivated == false)
            {
                IsActivated = true;
                OnTrapActivated?.Invoke();
                if (trapRenderer != null)
                {
                    trapRenderer.material.color = activatiodColor;
                }
            }
            else if (singleActivated == false)
            {
                IsActivated = false;
                OnTrapDeactivated?.Invoke();
                if(trapRenderer != null)
                {
                    trapRenderer.material.color = detectedColor;
                }
            }
        }
    }
}
