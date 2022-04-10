using UnityEngine;
using UnityEngine.SceneManagement;
using Singleton;
using UIFramework;
using System.Collections.Generic;
using System.Collections;

public class SceneJump : MonoBehaviour
{
    public static SceneType NowScene = SceneType.Start;
    public static SceneJump Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }
    private void Start()
    {

    }
    /// <summary>
    /// 初次加载场景是也会调用
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    private void ChangedActiveScene(Scene current, Scene next)
    {
        Singleton<UIManager>.Instance.Init();
        if (NowScene == SceneType.Start)
        {
            Singleton<ContextManager>.Instance.Push(new BaseContext(UIType.StartCanvas));
        }
        else if (NowScene == SceneType.Game)
        {
            GameControl.Instance.TurnStart();
            Singleton<ContextManager>.Instance.Push(new GameCanvasContext(UIType.GameCanvas));
        }
        else if (NowScene == SceneType.Shop)
        {
            Singleton<ContextManager>.Instance.Push(new ShopCanvasContext(UIType.ShopCanvas));
        }
    }
    public void Jump(SceneType sceneType)
    {
        Singleton<ContextManager>.Instance.Clear();
        NowScene = sceneType;
        if (sceneType == SceneType.Start)
        {
            SceneManager.LoadScene("Start");
        }
        else if (sceneType == SceneType.Shop)
        {
            SceneManager.LoadScene("Shop");
        }
        else if (sceneType == SceneType.Game)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
