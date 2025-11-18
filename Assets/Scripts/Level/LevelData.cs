using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    public int levelID;
    public int mazeWidth = 5;
    public int mazeHeight = 5;
    public Color paintColor = Color.red;
    public int[] wallPositions; // Vị trí tường trong grid
    public Vector2Int startPosition;
}
