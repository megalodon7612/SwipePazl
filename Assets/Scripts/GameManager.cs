using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleMask;

    public UnityEvent OnWin;
    public UnityEvent OnLoss;

    [SerializeField]private FlagServis[] flags;

    public bool GameOver { get; private set; }

    private void Awake()
    {
        RaycastCheck.ObstacleMask = obstacleMask;
        if (flags.Length > 0)
        {
            for (int i = 0; i < flags.Length; i++)
            {
                flags[i].OnFlagActivated.AddListener(ChecksFlagsActivity);
                flags[i].OnFlagDeactivated.AddListener(ChecksFlagsActivity);
            }
        }
    }

    private void Win()
    {
        if (GameOver==false)
        {
            GameOver = true;
            Debug.Log("win");
            OnWin?.Invoke();
        }
    }

    private void Loss()
    {
        if (GameOver == false)
        {
            GameOver = true;
            Debug.Log("loss");
            OnLoss?.Invoke();
        }
    }

    private void ChecksFlagsActivity()
    {
        for(int i = 0; i < flags.Length; i++)
        {
            if (flags[i].IsActivated == false)
            {
                return;
            }
            Win();
        }
    }
}
