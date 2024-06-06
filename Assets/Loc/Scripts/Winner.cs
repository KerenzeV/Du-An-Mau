

using UnityEngine;

public class Winner : MonoBehaviour
{
    public GameObject winnerPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winnerPanel.SetActive(true);
        }
    }
}
