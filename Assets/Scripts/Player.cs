using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public Text healthText;

    private int health;

    void Start() {
        health = maxHealth;
        updateHealthText();
    }

    public void takeDamage(int damage) {
        health -= damage;
        updateHealthText();
        if (health <= 0) {
            Debug.Log("Player Died!!");
            SceneManager.LoadScene(0);
        }
    }

    void updateHealthText() {
        healthText.text = "Health: " + health.ToString();
    }
}
