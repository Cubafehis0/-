[System.Serializable]
public class TreasureidIntSerializableDictionary: SerializableDictionary<TreasureID, int>{}
[System.Serializable]
public class LevelData
{
    public TreasureidIntSerializableDictionary treasureInfo;
    public int level;
    public int targetScore;
    public int time;
    public LevelData() {
        treasureInfo = new TreasureidIntSerializableDictionary();
    }
}

