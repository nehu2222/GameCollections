using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI Open시 인스턴스가 존재하지 않을 경우 생성하여 각 UI 타입의 Dictionary와 Stack에 저장해준다
/// UI Open시 인스턴스가 존재할 경우 Dictionary에서 찾아 활성화 후 Stack에 저장해준다
/// UI Close시 기본적으로 Stack에서만 제거해주고 비활성화 해준다
/// UI를 완전히 제거할 경우 Stack과 Dictionary에서 제거해주고 인스턴스를 파괴한다
/// UIHud는 게임을 플레이하는 동안 제거될 일이 없기 때문에 절대 파괴되지 않는다
/// </summary>

public class UIManager : MonoSingleton<UIManager>
{
    /// <summary>
    /// 각 UI 종류에 따른 최상위 오브젝트
    /// </summary>
    [SerializeField]
    public GameObject HudParent;
    [SerializeField]
    public GameObject PanelParent;
    [SerializeField]
    public GameObject PopupParent;

    public Stack<UIBase> UIAllStack { get; set; }

    public Dictionary<string, UIHud> UIHudDic { get; set; }
    public Dictionary<string, UIPanel> UIPanelDic { get; set; }
    public Dictionary<string, UIPopup> UIPopupDic { get; set; }

    public override void Awake()
    {
        base.Awake();

        if (HudParent == null)
        {
            HudParent = GameObject.Find("HudParent");
        }

        if (PanelParent == null)
        {
            PanelParent = GameObject.Find("PanelParent");
        }

        if (PopupParent == null)
        {
            PopupParent = GameObject.Find("PopupParent");
        }
    }

    private T CreateUI<T>() where T : UIBase
    {
        string uiName = typeof(T).Name;

        GameObject obj = new GameObject();
        obj.name = uiName;
        T ui = obj.AddComponent<T>();

        if (ui is UIHud)
        {
            UIHudDic.Add(uiName, ui as UIHud);
        }
        else if (ui is UIPanel)
        {
            UIAllStack.Push(ui);
            UIPanelDic.Add(uiName, ui as UIPanel);
        }
        else if (ui is UIPopup)
        {
            UIAllStack.Push(ui);
            UIPopupDic.Add(uiName, ui as UIPopup);
        }

        return ui;
    }

    private bool DestoryUI<T>() where T : UIBase
    {
        //< 미완

        T ui = null;
        string uiName = typeof(T).Name; ;

        if (UIHudDic.TryGetValue(uiName, out UIHud uiHud))
        {
            ui = uiHud as T;
            return true;
        }
        else if (UIPanelDic.TryGetValue(uiName, out UIPanel uiPanel))
        {
            ui = uiPanel as T;
            return true;
        }
        else if (UIPopupDic.TryGetValue(uiName, out UIPopup uiPopup))
        {
            ui = uiPopup as T;
            return true;
        }

        return false;
    }

    public T OpenUI<T>() where T : UIBase
    {
        string uiName = typeof(T).Name;

        T ui = null;

        if (UIHudDic.TryGetValue(uiName, out UIHud uiHud))
        {
            ui = uiHud as T;
        }
        else if (UIPanelDic.TryGetValue(uiName, out UIPanel uiPanel))
        {
            UIPanelDic.Add(uiName, uiPanel);
            ui = uiPanel as T;
        }
        else if (UIPopupDic.TryGetValue(uiName, out UIPopup uiPopup))
        {
            UIPopupDic.Add(uiName, uiPopup);
            ui = uiPopup as T;
        }
        else
        {
            ui = CreateUI<T>();  
        }

        ui.gameObject.SetActive(true);

        return ui;
    }

    public bool IsOpen<T>()
    {
        string uiName = typeof(T).Name;

        if (UIHudDic.TryGetValue(uiName, out UIHud uiHud))
        {
            return uiHud.gameObject.activeSelf;    
        }
        else if (UIPanelDic.TryGetValue(uiName, out UIPanel uiPanel))
        {
            return uiPanel.gameObject.activeSelf;    
        }
        else if (UIPopupDic.TryGetValue(uiName, out UIPopup uiPopup))
        {
            return uiPopup.gameObject.activeSelf;    
        }

        return false;
    }

    public void CloseUI<T>() where T : UIBase
    {
        //< 미완
        Type t = typeof(T);


    }

    public void PopUI()
    {
        if (UIAllStack.Count == 0)
            return;

        UIBase ui = UIAllStack.Pop();
        ui.gameObject.SetActive(false);
    }




    //< ============================================================================================================
    //< 이 밑으로는 만들지 고민 
    //< ============================================================================================================

    public UIHud OpenHud()
    {
        UIHud uiHud = CreateUI<UIHud>();
        return uiHud;
    }

    public void CloseHud()
    {

    }

    public void OpenPanel<UIPanel>()
    {

    }

    public void ClosePanel<UIPanel>()
    {

    }

    public void OpenPopup<UIPanel>()
    {

    }
    public void ClosePopup<UIPanel>()
    {

    }
}
