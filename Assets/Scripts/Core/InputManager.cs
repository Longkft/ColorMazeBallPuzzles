using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Swipe Settings")]
    [SerializeField] private float swipeThreshold = 50f;
    [SerializeField] private BallController ballController;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private bool isDragging = false;

    private void Update()
    {
        // Hỗ trợ cả touch và mouse cho testing
/*#if UNITY_EDITOR
        HandleMouseInput();
#else*/
        HandleTouchInput();
/*#endif*/
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                currentTouchPosition = touch.position;
                Vector2 swipeDelta = currentTouchPosition - startTouchPosition;

                if (swipeDelta.magnitude > swipeThreshold)
                {
                    Vector2 direction = swipeDelta.normalized;
                    ballController.Move(direction);
                    startTouchPosition = currentTouchPosition; // Continuous movement
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            currentTouchPosition = Input.mousePosition;
            Vector2 swipeDelta = currentTouchPosition - startTouchPosition;

            if (swipeDelta.magnitude > swipeThreshold)
            {
                Vector2 direction = swipeDelta.normalized;
                ballController.Move(direction);
                startTouchPosition = currentTouchPosition;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
