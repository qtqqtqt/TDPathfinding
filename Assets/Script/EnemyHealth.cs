using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] int maximumHealth = 5;
    int currentHealth;



    Enemy enemy;

    private void OnEnable()
    {
        currentHealth = maximumHealth;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        GetHit();
    }

    private void GetHit()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            maximumHealth += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
