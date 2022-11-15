
public class LoadingScreen : UIScreen
{
    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Initialize()
    {
        Hide();
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }
}
