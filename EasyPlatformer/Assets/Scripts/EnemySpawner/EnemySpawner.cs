using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _spawnDelay;
    [SerializeField] private int _timeToDestoy;

    private float _nextSpawnDelay;

    private void Update()
    {
        if (Time.time > _nextSpawnDelay)
        {
            _nextSpawnDelay = Time.time + _spawnDelay;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        Destroy(enemy.gameObject, _timeToDestoy);
    }
}
