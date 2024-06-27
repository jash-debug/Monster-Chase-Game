using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float duration = 5f;
    Color currentColor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        PowerupManager powerupManager = player.GetComponent<PowerupManager>();
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        currentColor = spriteRenderer.color;
        powerupManager.SetIndestructible(true);
        
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);

        yield return new WaitForSeconds(duration);
        powerupManager.SetIndestructible(false);
        spriteRenderer.color = currentColor;
        Destroy(gameObject);
    }
}
