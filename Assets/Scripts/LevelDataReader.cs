using UnityEngine;


public static class LevelDataReader
{
    private class LevelDataArray
    {
        public LevelData[] json;
    }

    public static LevelData[] GetLevelDatas(int level)
    {
        string jsonText = Resources.Load<TextAsset>("Levels/level" + level).text;
        return JsonUtility.FromJson<LevelDataArray>(jsonText).json;
    }
}