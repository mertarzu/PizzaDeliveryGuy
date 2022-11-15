using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : UIScreen
{
    public Action OnNextLevelPressed;
    [SerializeField] Button _nextLevelButton;
    [SerializeField] TextMeshProUGUI _scoreText;

    public override void Hide()
    {
        gameObject.SetActive(false);
        _nextLevelButton.gameObject.SetActive(false);
    }

    public override void Initialize()
    {
        Hide();
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        _nextLevelButton.gameObject.SetActive(true);
        _scoreText.text = "$" + DataHandler.Money.ToString();
    }

    public void NextLevelPressed()
    {
        Hide();
        OnNextLevelPressed();
    }
}
