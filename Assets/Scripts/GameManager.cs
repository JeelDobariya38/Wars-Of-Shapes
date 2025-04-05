using UnityEngine;
using WarsOfShapes.Scriptables;

namespace WarsOfShapes
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Game gamesetup;
        [SerializeField] private Transform enemyParent;

        private void Awake()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Movement>().Init(gamesetup.PlayerSpeed);
            player.GetComponent<Player>().Init(gamesetup.PlayerHealth);

            for (int i=0; i<gamesetup.NoOfEnemy; i++) 
            {
                Vector3 spawnPosition = new Vector3(Random.Range(gamesetup.MinArea.x, gamesetup.MaxArea.x), Random.Range(gamesetup.MinArea.y, gamesetup.MaxArea.y), 0);
                Enemy enemy = Instantiate(gamesetup.EnemyPrefab, spawnPosition, Quaternion.identity, enemyParent);
                enemy.Init(gamesetup.EnemySpeed, gamesetup.EnemyStoppingDistance, gamesetup.EnemyRetreatDistance, gamesetup.EnemyTimeBtwShoot);
            }
        }
    }
}
