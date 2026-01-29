using UnityEngine;



public class TestObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            UIManager.Instance.OpenUI<UIPanel_Test>();
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            UIManager.Instance.OpenUI<UIPanel_Test2>();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            UIManager.Instance.CloseUI<UIPanel_Test>();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            UIManager.Instance.CloseUI<UIPanel_Test2>();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            UIManager.Instance.PopUI();
        }
    }
}
