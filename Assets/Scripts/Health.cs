using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float maxhealth = 10;
    [SerializeField] public float health = 10;
    [SerializeField] float score = 1;
    [SerializeField] float buffDropChance = 0.01f;
    [SerializeField] GameObject buffPrefab;
    // Start is called before the first frame update

    public delegate void HealthChanged(float healthPercentage);
    public event HealthChanged OnHealthChanged;
    void Start()
    {
        health = maxhealth;
        NotifyHealthChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        health = Mathf.Clamp(health, 0, maxhealth);
        NotifyHealthChange();

        if (health <= 0)
        {
            Death();
        }
    }
    public void NotifyHealthChange()
    {
        if (OnHealthChanged != null)
        {
            float healthPercentage = health / maxhealth;
            OnHealthChanged(healthPercentage);
        }
    }

    public void Death()
    {
        if (Random.value < buffDropChance)
        {
            Instantiate(buffPrefab, transform.position, Quaternion.identity);
        }
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreCounter>().AddScore(score);
        Destroy(gameObject);
    }   
}
