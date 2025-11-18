using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    // Tham chiếu đến Event Channel
    [SerializeField] private GameEvent gameEvent;

    // Response - gì sẽ xảy ra khi event được phát
    [SerializeField] private UnityEvent response;

    private void OnEnable()
    {
        // Đăng ký khi object được enable
        if (gameEvent != null)
            gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        // Hủy đăng ký khi object disable
        if (gameEvent != null)
            gameEvent.UnregisterListener(this);
    }

    /// <summary>
    /// Được gọi khi event được phát
    /// </summary>
    public void OnEventRaised()
    {
        response?.Invoke();
    }
}
