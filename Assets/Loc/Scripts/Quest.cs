using UnityEngine;
using TMPro; 
using System.Collections;

public class TMP_NotificationManager : MonoBehaviour
{
    public GameObject notificationPanel;
    public TMP_Text[] notificationTexts;
    public float[] displayTimes;
   
    private bool isSkipping = false; 

    void Start()
    {
        StartCoroutine(ShowNotifications());
    }

    IEnumerator ShowNotifications()
    {
        notificationPanel.SetActive(true);

        for (int i = 0; i < notificationTexts.Length; i++)
        {
            notificationTexts[i].gameObject.SetActive(true);

            float timeLeft = displayTimes[i];
            while (timeLeft > 0.0f && !isSkipping)
            {
                yield return null;
                timeLeft -= Time.deltaTime;
            }

            if (!isSkipping)
            {
                notificationTexts[i].gameObject.SetActive(false);
            }
        }

        notificationPanel.SetActive(false);
    }

    public void SkipNotifications()
    {
        isSkipping = true;
    }
}




