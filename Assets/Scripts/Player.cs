using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth;

    private int health;

    void Start() {
        health = maxHealth;
    }

    public void takeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Debug.Log("Player Died!!");
            SceneManager.LoadScene(0);
        }
    }
}
