using UnityEngine;

/// <summary>
/// UI Parent 클래스
/// UI는 Hud, Panel, Popup으로 나눈다
/// </summary>

public class UIBase : MonoBehaviour
{
    public virtual void OpenUI() {}

    public virtual void CloseUI() {}

    public virtual void Awake() {}

    public virtual void OnEnable() {}

    public virtual void OnDisable() {}

    public virtual void OnDestroy() {}
}
