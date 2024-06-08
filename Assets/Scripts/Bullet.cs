using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float damage = -1;
    [SerializeField] string damageTag = "Enemy";
    [SerializeField] GameObject buffPrefab;
    [SerializeField] float buffDropChance = 0.3f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(damageTag))
        {
            collision.gameObject.GetComponent<Health>().AddHealth(damage);
            Destroy(gameObject);
        }

    }
}
