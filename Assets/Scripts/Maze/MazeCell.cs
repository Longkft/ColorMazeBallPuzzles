using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public int x { get; private set; }
    public int z { get; private set; }
    public bool isPainted { get; private set; }

    private Renderer cellRenderer;
    private Color originalColor;
    private Color paintedColor;

    public void Initialize(int xPos, int zPos)
    {
        x = xPos;
        z = zPos;
        cellRenderer = GetComponent<Renderer>();
        originalColor = cellRenderer.material.color;
    }

    public void Paint(Color color)
    {
        isPainted = true;
        paintedColor = color;
        cellRenderer.material.color = color;
    }
}
