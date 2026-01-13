using UnityEngine;

/// <summary>
/// 게임의 현재 상태를 보여주는 Hud의 베이스 클래스
/// Hud는 제거되지 않고 비활성화 상태로 무조건 유지된다
/// </summary>

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
