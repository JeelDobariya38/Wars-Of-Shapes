using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth;

    public GameManager gameManager;

    public TextMeshProUGUI healthText;

    private int health;

    void Start() {
        health = maxHealth;
        updateHealthText();
    }

    public void takeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            health = 0;
            gameManager.GameOver();
        }

        updateHealthText();
    }

    void updateHealthText() {
        healthText.text = "Health: " + health.ToString();
    }
}
