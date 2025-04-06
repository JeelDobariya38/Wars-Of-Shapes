using UnityEngine;
using WarsOfShapes.Scriptables;

namespace WarsOfShapes
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Game gameData;

        private void Start()
        {
            SpawnPlayer();
            SpawnEnemies();
        }

        private void SpawnPlayer()
        {
            Player player = Instantiate(gameData.PlayerPrefab, Vector3.zero, Quaternion.identity);
            player.Init(gameData.PlayerSpeed, gameData.PlayerHealth);
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < gameData.NoOfEnemy; i++)
            {
                Vector3 spawnPos = GetRandomSpawnPosition();
                Enemy enemy = Instantiate(gameData.EnemyPrefab, spawnPos, Quaternion.identity);
                enemy.Init(gameData.EnemySpeed, gameData.EnemyStoppingDistance, gameData.EnemyRetreatDistance, gameData.EnemyTimeBtwShoot);
            }
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float x = Random.Range(gameData.MinArea.x, gameData.MaxArea.x);
            float y = Random.Range(gameData.MinArea.y, gameData.MaxArea.y);
            return new Vector3(x, y, 0);
        }
    }
}
