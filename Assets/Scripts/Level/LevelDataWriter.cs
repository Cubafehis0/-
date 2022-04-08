using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelDataWriter : MonoBehaviour
{
    public LevelData levelData;
    static string LevelPath = Path.Combine(@"C:/Users/26560/Documents/GameProject/GoldMinner/Assets/Resources", "Levels");
    [ContextMenu("写入")]
    public void WriteIntoFile()
    {
        string json = JsonUtility.ToJson(levelData);
        string path = Path.Combine(LevelPath, "level" + levelData.level + ".json");
        if(File.Exists(path)) File.Delete(path);
        File.Create(path).Dispose();
        File.WriteAllText(path, json);
        Debug.Log($"成功在{path}写入关卡信息");
    }
}
