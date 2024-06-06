using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float coinValue = 100;
    [SerializeField] AudioClip coinPickupSFX;

    // Coin check
    private bool isCollected = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Coin check
            isCollected = true;
           
            // Add score
            FindObjectOfType<GameController>().AddScore((int)coinValue);

            // Play Sound
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);

            // Destroy
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}




