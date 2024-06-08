using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    private GameObject buffPrefab;
    private float buffDropChance;

    public void Initialize(GameObject buffPrefab, float buffDropChance)
    {
        this.buffPrefab = buffPrefab;
        this.buffDropChance = buffDropChance;
    }

    public void SpawnBuff()
    {
        if (Random.value < buffDropChance)
        {
            Instantiate(buffPrefab, transform.position, Quaternion.identity);
        }
    }
}
