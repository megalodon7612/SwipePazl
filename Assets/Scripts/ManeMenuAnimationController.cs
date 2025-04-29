using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManeMenuAnimationController : MonoBehaviour
{
    [SerializeField] private Transform startButton;
    [SerializeField] private Transform setingsButton;
    [SerializeField] private Transform exitButton;

    private const float START_BUTTON_START_POSITION = -1000;
    private const float SETINGS_BUTTON_START_POSITION = -1000;
    private const float EXIT_BUTTON_START_POSITION = -1000;

    private void OnEnable()
    {
        var startButtonPosition = startButton.localPosition;
        var setingsButtonPosition = setingsButton.localPosition;
        var exitButtonPosition = exitButton.localPosition;

        startButton.localPosition = new Vector3(START_BUTTON_START_POSITION, startButton.localPosition.y, startButton.localPosition.z);
        setingsButton.localPosition = new Vector3(SETINGS_BUTTON_START_POSITION, setingsButton.localPosition.y, setingsButton.localPosition.z);
        exitButton.localPosition = new Vector3(EXIT_BUTTON_START_POSITION, exitButton.localPosition.y, exitButton.localPosition.z);

        startButton.DOLocalMove(startButtonPosition, 0.5f).OnComplete(()=>
        setingsButton.DOLocalMove(setingsButtonPosition, 0.5f).OnComplete(() =>
        {
            exitButton.DOLocalMove(exitButtonPosition, 0.5f);
        }));
    }
}

