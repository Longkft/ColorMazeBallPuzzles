using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody rb;
    private TrailRenderer trailRenderer;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float drag = 3f;

    [Header("Maze Settings")]
    [SerializeField] private float cellSize = 1f; // Kích thước 1 ô trong maze

    [Header("Events")]
    [SerializeField] private GameEvent onPathCompleted;

    private Vector2 moveInput;
    private HashSet<Vector2Int> paintedCells = new HashSet<Vector2Int>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();
        rb.linearDamping = drag;
    }

    public void Move(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x, 0, direction.y);
        rb.AddForce(movement * moveSpeed, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MazeCell"))
        {
            Vector2Int cellPos = GetCellPosition(other.transform.position);
            PaintCell(cellPos);
        }
    }

    /// <summary>
    /// Chuyển đổi world position thành cell grid position
    /// </summary>
    private Vector2Int GetCellPosition(Vector3 worldPosition)
    {
        // Làm tròn world position thành grid coordinates
        int x = Mathf.RoundToInt(worldPosition.x / cellSize);
        int z = Mathf.RoundToInt(worldPosition.z / cellSize);

        return new Vector2Int(x, z);
    }

    private void PaintCell(Vector2Int cellPos)
    {
        if (!paintedCells.Contains(cellPos))
        {
            paintedCells.Add(cellPos);

            // TODO: Change material color ở đây
            // Ví dụ: GetCellAtPosition(cellPos)?.Paint(currentColor);

            CheckLevelComplete();
        }
    }

    private void CheckLevelComplete()
    {
        // TODO: So sánh với tổng số cells cần paint
        // if (paintedCells.Count >= totalCellsInMaze)
        // {
        //     onPathCompleted?.Raise();
        // }
    }
}

