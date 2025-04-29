using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagServis : MonoBehaviour
{
    public UnityEvent OnFlagActivated;
    public UnityEvent OnFlagDeactivated;

    public bool IsActivated = false;

    [SerializeField] private bool singleActivated = true;
    [SerializeField] private float serchRadius;
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private Renderer flagRenderer;
    [SerializeField] private Color activatedColor;
    [SerializeField] private Color deactivatedColor;
    [SerializeField] private LayerMask targetMask;

    private void Awake()
    {
        if (flagRenderer!=null)
        {
            if (IsActivated == false)
            {
                flagRenderer.material.color = deactivatedColor;
            }
            else
            {
                flagRenderer.material.color= activatedColor;
            }
        }

        if (IsActivated == true)
        {
            OnFlagActivated?.Invoke();
        }

        if (detectionPoint == null)
        {
            detectionPoint = transform;
        }
    }

    private void FixedUpdate()
    {
        Collider[] targetColiders = Physics.OverlapSphere(detectionPoint.position,serchRadius,targetMask);
        if (targetColiders.Length > 0)
        {
            if (IsActivated == false)
            {
                IsActivated = true;
                OnFlagActivated?.Invoke();

                if (flagRenderer != null)
                {
                    flagRenderer.material.color = activatedColor;
                }
            }
        }

        else if (singleActivated == false)
        {
            IsActivated = false;
            OnFlagDeactivated?.Invoke();

            if (flagRenderer != null)
            {
                flagRenderer.material.color = deactivatedColor;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (IsActivated == false)
        {
            Gizmos.color = Color.red;
        }

        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawWireSphere(detectionPoint.position, serchRadius);
    }
}
