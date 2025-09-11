using System.Collections;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        StartCoroutine(CoStart());
    }

    IEnumerator CoStart()
    {
        yield return null;
    }

    private void InitGame()
    {
        
    }
}
