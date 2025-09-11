using UnityEngine;

public class UIHud : UIBase
{
    public override void OpenUI()
    {
        base.OpenUI();
    }

    public override void CloseUI()
    {
        this.gameObject.SetActive(false);
        return;
    }
}
