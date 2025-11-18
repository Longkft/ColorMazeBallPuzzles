using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private LevelData[] allLevels;
    [SerializeField] private MazeGenerator mazeGenerator;

    private int currentLevelIndex = 0;

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < allLevels.Length)
        {
            currentLevelIndex = levelIndex;
            LevelData levelData = allLevels[levelIndex];
            mazeGenerator.GenerateMaze(levelData);
        }
    }

    public void LoadNextLevel()
    {
        LoadLevel(currentLevelIndex + 1);
    }
}
