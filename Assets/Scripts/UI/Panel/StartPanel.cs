using UnityEngine;

public class StartPanel : UIPanel
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OpenUI()
    {
        base.OpenUI();
    }

    public override void CloseUI()
    {
        base.CloseUI();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public void OnClickStart()
    {
        //< 메인씬으로 전환
        ScenesManager.Instance.LoadAsyncSceneAsync("MainScene");
        Debug.Log("ClickStart");
    }
}
