using UnityEngine;
using UnityEngine.SceneManagement;
using Singleton;
using UIFramework;
public class SceneJump : MonoBehaviour
{
    public static SceneType NowScene = SceneType.Start;
    public static SceneJump instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
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
        Debug.Log("SceneChange");
        Singleton<UIManager>.Instance.Init();
        if (NowScene == SceneType.Start)
        {
            Singleton<ContextManager>.Instance.Push(new BaseContext(UIType.StartCanvas));
        }
        else if (NowScene == SceneType.Game)
        {
            Singleton<ContextManager>.Instance.Push(new GameCanvasContext(UIType.GameCanvas));
            PlayerDataMgr.Instance.GameStart();
        }
        else if (NowScene == SceneType.Game)
        {
            //SceneManager.LoadScene("start");
        }
    }
    public void Jump(SceneType sceneType)
    {
        Singleton<ContextManager>.Instance.Clear();
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
        NowScene = sceneType;
    }
}
