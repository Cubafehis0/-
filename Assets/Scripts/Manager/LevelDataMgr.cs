using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataMgr : MonoBehaviour
{
    public static LevelDataMgr Instance;
    private List<LevelData> levelsData = new List<LevelData>();
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        foreach (var json in Resources.LoadAll<TextAsset>("Levels"))
        {
            levelsData.Add(JsonUtility.FromJson<LevelData>(json.text));
        }
        levelsData.Sort((l, r) => l.level - r.level);
    }
    public int LevelCount=>levelsData.Count;
    public LevelData GetLevelInfo(int level)
    {
        return levelsData[level - 1];
    }
}
