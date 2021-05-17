using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float startSpeed = 10f;

    public float startHealth = 100;
    public float health;
    public GameObject deathEffect;
    public Image healthBar;


    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float amount) 
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health < 0) 
        {
            Die();
        }
    }

    public void BaseDamage() 
    {
        PlayerStats.Lives--;
    }

    void Die() 
    {
        GameObject deadEffect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deadEffect, 5f);
        Destroy(this.gameObject);
        PlayerStats.money += 100;
    }

    public void Slow(float slowPrc) 
    {
        speed = startSpeed * (1 * slowPrc);
    }


}
