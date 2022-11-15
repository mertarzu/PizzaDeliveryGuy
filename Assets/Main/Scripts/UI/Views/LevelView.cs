using TMPro;
using UnityEngine;

public class LevelView : UIView
{
    [SerializeField] TextMeshProUGUI _levelText;
    public override void Initialize()
    {
        _levelText.text = "LEVEL " + DataHandler.UILevel.ToString();
    }
    public override void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
    public override void UpdateView()
    {
        _levelText.text = "LEVEL " + DataHandler.UILevel.ToString();

    }
}
                                                            