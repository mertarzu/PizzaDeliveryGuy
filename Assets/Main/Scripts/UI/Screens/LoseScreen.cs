using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : UIScreen
{
    public Action OnReplayPressed;
    [SerializeField] Button replayButton;

    public override void Hide()
    {
        gameObject.SetActive(false);
        replayButton.gameObject.SetActive(false);
    }

    public override void Initialize()
    {
        Hide();
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        replayButton.gameObject.SetActive(true);
    }

    public void ReplayPressed()
    {
        Hide();
        OnReplayPressed();
    }
}
