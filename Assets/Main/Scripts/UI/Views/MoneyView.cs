using TMPro;
using UnityEngine;

public class MoneyView : UIView
{
    [SerializeField] TextMeshProUGUI _moneyText;
    [SerializeField] PlayerStackItemHandler _playerStackItemHandler;
    public override void Initialize()
    {
        _moneyText.text = DataHandler.Money.ToString();
        _playerStackItemHandler.OnMoneyChange += UpdateView;
    }

    public override void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public override void UpdateView()
    {
        _moneyText.text = DataHandler.Money.ToString();

    }
}
