using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float duration = 5f;
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

        powerupManager.Indestructible = true;
        Color currentColor = spriteRenderer.color;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);

        yield return new WaitForSeconds(duration);
        powerupManager.Indestructible = false;
        spriteRenderer.color = currentColor;
        Destroy(gameObject);
    }
}
