using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManeMenuController : MonoBehaviour
{
    [SerializeField] private GameObject maneMenu;
    [SerializeField] private GameObject levelesMenu;
    [SerializeField] private GameObject setingsMenu;

    public void StartButton()
    {
        maneMenu.SetActive(false);
        levelesMenu.SetActive(true);
    }
    
    public void SetingsButton()
    {
        maneMenu.SetActive(false);
        levelesMenu.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
