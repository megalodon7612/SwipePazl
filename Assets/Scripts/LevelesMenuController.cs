using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelesMenuController : MonoBehaviour
{
    [SerializeField] private GameObject maneMenu;
    [SerializeField] private GameObject levelesMenu;

    public void Back()
    {
        levelesMenu.SetActive(false);
        maneMenu.SetActive(true);
    }
}
