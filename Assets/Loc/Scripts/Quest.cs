using UnityEngine;
using TMPro; 
using System.Collections;

public class TMP_NotificationManager : MonoBehaviour
{
    public GameObject notificationPanel;
    public TMP_Text[] notificationTexts; 
    
    public float[] displayTimes; 


    void Start()
    {
        HideAllTexts();
        StartCoroutine(ShowNotifications());
    }
    void HideAllTexts()
    {
        foreach (TMP_Text text in notificationTexts)
        {
            text.gameObject.SetActive(false);
        }
    }

    IEnumerator ShowNotifications()
    {
        notificationPanel.SetActive(true);

        for (int i = 0; i < notificationTexts.Length; i++)
        {
            notificationTexts[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(displayTimes[i]);
            notificationTexts[i].gameObject.SetActive(false);
        }

        notificationPanel.SetActive(false);
    }
}



