    using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJump : MonoBehaviour
{
    public static SceneType NowScene = SceneType.Start;
    public GameObject IconCanvasObj;
    public GameObject ShopCanvasObj;
    public GameObject StartCanvasObj;

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

    /// <summary>
    /// 初次加载场景是也会调用
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    private void ChangedActiveScene(Scene current, Scene next)
    {
        Debug.Log("SceneChange");
        //string currentName = current.name;

        //if (currentName == null)
        //{
        //    // Scene1 has been removed
        //    currentName = "Replaced";
        //}

        //Debug.Log("Scenes: " + currentName + ", " + next.name);

        if (NowScene == SceneType.Start)
        {
            Instantiate(StartCanvasObj);
        }
        else if (NowScene == SceneType.Game)
        {
            Instantiate(IconCanvasObj);
        }
        else if (NowScene == SceneType.Game)
        {
            //SceneManager.LoadScene("start");
        }
    }


    // Use this for initialization
    void Start()
    {
        //Application.LoadLevel("start");
    }

    public void Jump(SceneType sceneType)
    {
        if (sceneType == SceneType.Start)
        {
            SceneManager.LoadScene("start");
        }
        else if (sceneType == SceneType.Shop)
        {
            SceneManager.LoadScene("start");
        }
        else if (sceneType == SceneType.Game)
        {
            SceneManager.LoadScene("battle");
        }
        NowScene = sceneType;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
