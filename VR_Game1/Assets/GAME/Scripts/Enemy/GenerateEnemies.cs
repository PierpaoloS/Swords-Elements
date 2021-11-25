using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject fireEnemy;
    public GameObject stoneEnemy;
    public float xPos;
    public float zPos;
    public int enemyCount;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            int x = Random.Range(0, 2);
            xPos = Random.Range(-10, 10);
            zPos = Random.Range(-10, 10);
            switch (x)
            {
                case 0:
                    Instantiate(fireEnemy, new Vector3(xPos, 1f, zPos), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(stoneEnemy, new Vector3(xPos, 1f, zPos), Quaternion.identity);
                    break;
            }

            yield return new WaitForSeconds(5f);
            enemyCount += 1;
        }
    }
}


