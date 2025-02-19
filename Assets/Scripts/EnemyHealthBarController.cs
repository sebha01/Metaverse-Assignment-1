using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarController : MonoBehaviour
{
    public Image healthBar;
    public int health;
    public int startHealth;

    public void updateHealth(int decrementHealth)
    {
        health = health - decrementHealth;
        healthBar.fillAmount = health / startHealth;
    }
}

