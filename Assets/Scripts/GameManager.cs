using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleMask;

    private void Awake()
    {
        RaycastCheck.ObstacleMask = obstacleMask;
    }
}
