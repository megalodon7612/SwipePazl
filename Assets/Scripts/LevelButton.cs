using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int number;

    public void OpenLevel()
    {
        SceneManager.LoadScene(number);
    }
}
