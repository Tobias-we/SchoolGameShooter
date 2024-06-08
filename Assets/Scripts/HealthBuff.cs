using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    [SerializeField] float healAmount = 5;
    [SerializeField] string playerTag = "Player";
    [SerializeField] float destroyDelay = 0.1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.health = playerHealth.maxhealth;
                playerHealth.NotifyHealthChange();
            }

            Destroy(gameObject, destroyDelay); 
        }
    }
}
