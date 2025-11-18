[System.Serializable]
public class SaveData
{
    public int currentLevel;
    public int highestUnlockedLevel;
    public int totalStars;
    public bool[] levelCompletion;

    public SaveData()
    {
        currentLevel = 0;
        highestUnlockedLevel = 0;
        totalStars = 0;
        levelCompletion = new bool[50]; // 50 levels
    }
}
