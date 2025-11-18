using UnityEngine;

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    LevelComplete
}

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static GameManager Instance { get; private set; }

    [Header("ScriptableObject References")]
    [SerializeField] private GameEvent onLevelComplete;
    [SerializeField] private GameEvent onLevelFailed;

    private GameState currentState = GameState.MainMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CompleteLevel()
    {
        onLevelComplete.Raise();
        SaveProgress();
    }

    private void SaveProgress()
    {
        // Sử dụng JSON để save data
        /*string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("SaveData", json);*/
    }
}
