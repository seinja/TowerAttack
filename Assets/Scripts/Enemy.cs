using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float startSpeed = 10f;

    public float Health = 100;
    public GameObject deathEffect;


    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount) 
    {
        Health -= amount;

        if (Health < 0) 
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
