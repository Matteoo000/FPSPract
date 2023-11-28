using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject Enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
