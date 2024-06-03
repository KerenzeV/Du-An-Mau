
using UnityEngine;
using TMPro;

public class NotificationPanel : MonoBehaviour
{
    public GameObject notificationPanel;
    public TMP_Text notificationText;

    private float notificationDuration = 5f;
    private float notificationTimer;

    private void Start()
    {
        ShowNotification("Your Objective\r\nCollect All Coins: Don't miss any coin. Each coin collected brings you one step closer to victory.\r\n\r\n\r\nDefeat Monsters: Courageously confront and defeat all enemies along the way.\r\n\r\n\r\nAdvance to the Next Level: Complete the task of collecting and defeating to unlock new levels with more challenges.\r\n\r\n\r\nGet Ready\r\nStay Focused: Be ready to face any challenge.\r\n\r\n\r\nCombat Skills: Use all your skills to overcome obstacles and enemies.\r\n\r\n\r\nSmart Strategy: Think strategically to collect coins efficiently and defeat monsters safely");
    }

    private void Update()
    {
        if (notificationPanel != null && notificationPanel.activeSelf)
        {
            notificationTimer += Time.deltaTime;
            if (notificationTimer >= notificationDuration)
            {
                HideNotification();
            }
        }
    }

    public void ShowNotification(string message)
    {
        notificationText.text = message;
        if (notificationPanel != null)
            notificationPanel.SetActive(true);
        notificationTimer = 0f;
    }

    public void HideNotification()
    {
        if (notificationPanel != null)
            notificationPanel.SetActive(false);
    }
}
