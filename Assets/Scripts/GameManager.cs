using UnityEngine;
using WarsOfShapes.Scriptables;

namespace WarsOfShapes
{
    public class GameManager : MonoBehaviour
    {
        public Game gamesetup;

        private void Awake()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Movement>().Init(gamesetup.PlayerSpeed);
            player.GetComponent<Player>().Init(gamesetup.PlayerHealth);

            for (int i=0; i<gamesetup.NoOfEnemy; i++) 
            {
                Vector3 spawnPosition = new Vector3(Random.Range(0, 50), Random.Range(0, 50), 0);
                Enemy enemy = Instantiate(gamesetup.EnemyPrefab, spawnPosition, Quaternion.identity);
                enemy.Init(gamesetup.EnemySpeed, gamesetup.EnemyStoppingDistance, gamesetup.EnemyRetreatDistance, gamesetup.EnemyTimeBtwShoot);
            }
        }
    }
}
