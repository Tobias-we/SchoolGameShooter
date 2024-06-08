using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    [SerializeField] private float homingSpeed = 5f;
    private Transform player;
    
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * homingSpeed * Time.deltaTime;
            RotateTowardsPlayer(direction);
        }
    }
    private void RotateTowardsPlayer(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; 
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
