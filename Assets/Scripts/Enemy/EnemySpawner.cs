using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public void SpawnEnemy(int enemyIndex)
    {
        if (enemyIndex >= 0 && enemyIndex < enemyPrefabs.Length)
        {
            Instantiate(enemyPrefabs[enemyIndex], transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Invalid enemy index!");
        }
    }
}
