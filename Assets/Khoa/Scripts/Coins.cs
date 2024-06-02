using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coins : MonoBehaviour
{
    [SerializeField] int coinValue = 10;
    [SerializeField] AudioClip CoinsPickSFX;
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //tang diem
            FindObjectOfType<UIbyKhoa>().AddScore((int)coinValue);
            //play sound
            AudioSource.PlayClipAtPoint(CoinsPickSFX, Camera.main.transform.position);
            //destroy
            Destroy(gameObject);
        }
    }


}
