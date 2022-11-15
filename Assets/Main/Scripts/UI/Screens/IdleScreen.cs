using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleScreen : UIScreen
{
    public Action OnPlayPressed;
    [SerializeField] Button playButton;
    [SerializeField] List<UIView> uiViews;

    public override void Hide()
    {
        gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        foreach (var uiView in uiViews)
        {
            uiView.SetActive(false);
        }
    }

    public override void Initialize()
    {
        Hide();
        foreach (var uiView in uiViews)
        {
            uiView.Initialize();
        }
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        foreach (var uiView in uiViews)
        {
            uiView.SetActive(true);
            uiView.UpdateView();
        }
    }
    public void PlayPressed()
    {
        Hide();
        OnPlayPressed();
    }

}
