using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyAnimationController animController;
    public int health;
    private bool isDead = false;

    public EnemyManager manager;

    void Awake()
    {
        animController = GetComponent<EnemyAnimationController>();
    }
    public void SetHealth(int value)
    {
        health = value;
        isDead = false;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animController.TriggerDeath();

        manager.NextBoss();
    }
}