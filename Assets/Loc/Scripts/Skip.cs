using UnityEngine;
using UnityEngine.UI;

public class SkipButton : MonoBehaviour
{
    public TMP_NotificationManager notificationManager;

    void Start()
    {
        Button skipButton = GetComponent<Button>();
        skipButton.onClick.AddListener(SkipNotifications);
    }

    void SkipNotifications()
    {
        notificationManager.SkipNotifications();
    }
}
