using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private GameObject outherWallPrefab;
    [SerializeField] private GameObject wallPrefab;

    [Header("Container")]
    [SerializeField] private Transform mazeContainer;

    private MazeCell[,] mazeCells;

    public void GenerateMaze(LevelData levelData)
    {
        ClearMaze();

        int width = levelData.mazeWidth;
        int height = levelData.mazeHeight;
        mazeCells = new MazeCell[width, height];

        // Generate floor grid
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 position = new Vector3(x, 0, z);
                GameObject floor = Instantiate(floorPrefab, position, Quaternion.identity, mazeContainer);

                MazeCell cell = floor.AddComponent<MazeCell>();
                cell.Initialize(x, z);
                mazeCells[x, z] = cell;
            }
        }

        // Generate walls based on level data
        GenerateWalls(levelData.wallPositions);
    }

    private void GenerateWalls(int[] wallPositions)
    {
        // Logic đặt tường dựa trên array positions
        foreach (int pos in wallPositions)
        {
            int x = pos % mazeCells.GetLength(0);
            int z = pos / mazeCells.GetLength(0);

            Vector3 wallPos = new Vector3(x, 0.5f, z);
            Instantiate(wallPrefab, wallPos, Quaternion.identity, mazeContainer);
        }
    }

    private void ClearMaze()
    {
        foreach (Transform child in mazeContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
