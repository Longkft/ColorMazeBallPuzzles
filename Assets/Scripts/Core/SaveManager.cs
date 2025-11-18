using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string SAVE_KEY = "ColorMazeSave";
    private SaveData saveData;

    public void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
    }

    public SaveData LoadGame()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            return JsonUtility.FromJson<SaveData>(json);
        }
        return new SaveData();
    }

    public void UnlockLevel(int levelIndex)
    {
        saveData = LoadGame();
        if (levelIndex > saveData.highestUnlockedLevel)
        {
            saveData.highestUnlockedLevel = levelIndex;
            saveData.levelCompletion[levelIndex] = true;
            SaveGame(saveData);
        }
    }
}
