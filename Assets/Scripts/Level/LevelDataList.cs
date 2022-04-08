using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataList", menuName = "ScriptableObjects/LevelDataList", order = 1)]
public class LevelDataList : ScriptableObject
{
    public List<LevelData> levelsData;
    //static string LevelPath = Path.Combine(Application.dataPath, "Level");
    //[ContextMenu("–¥»Î")]
    //public void WriteIntoFile()
    //{
    //    foreach(LevelData data in levelsData)
    //    {
    //        string json = JsonUtility.ToJson(data);
    //        string path = Path.Combine(LevelPath, data.level + ".json");
    //        if (!File.Exists(path)) File.Create(path);
    //        File.WriteAllText(path, json);
    //    }
    //}
}
