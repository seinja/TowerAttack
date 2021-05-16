using UnityEngine;

public class Bullet : MonoBehaviour
{


    private float speed = 55f;
    public float explosionRadius = 0;
    private Transform target;
    public GameObject impactEffect;
    public GameObject deathEffect;
    public int damage = 15;



    // Метод через который мы связываем нашу турель и пулю передавая ей цель
    public void Seek(Transform _target) 
    {
        target = _target;
    }
    
    
    // Проверяем есть ли цель и выстраев к ней маршрут + передвигаем пулю + если мы попадаем в следующем фрейме вызываем метод попадания.
    void Update()
    {
        if (target == null) { Destroy(gameObject); return; }

        Vector3 dirtection = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dirtection.magnitude <= distanceThisFrame) 
        {
            HitTarget();
            return;

        }
        transform.Translate(dirtection.normalized * distanceThisFrame,Space.World);
        
        
    }


    // Попадаем в цель. Вызываем партиклы и потом их удаляем.
    void HitTarget() 
    {
        GameObject effectInstance = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 1f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else 
        {

            Damage(target);
        }

        Debug.Log("Hit");
        Destroy(gameObject);
    }

    void Explode() 
    {
       Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius);

        foreach (Collider collider in colliders) 
        {
            if (collider.tag == "Enemy") 
            {
                Damage(collider.transform);
            }
        }

    }

    void Damage(Transform enemy) 
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null) 
        {
            e.TakeDamage(damage);
        }
    }
}
