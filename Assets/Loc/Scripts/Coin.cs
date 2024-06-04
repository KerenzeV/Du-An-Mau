using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float coinValue = 100;
    [SerializeField] AudioClip coinPickupSFX;

    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;

            //Use Singleton Instance
            GameController.Instance.AddScore((int)coinValue);

            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}





