using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header ("Attributes")]
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    public float range = 15f;
    public bool isLaserWeapon = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public int damageOverTime = 40;
    public float slowPrc = .3f;



    [Header("Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private Enemy targetEnemy;
    


    void Start()
    {
        // Чтоб не грузить железо вызываем данный метод не в Апдейте, а через повторный вызов каждый пол секунды.
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {


        if (target == null)
        {
            if (isLaserWeapon) 
            {
                if (lineRenderer.enabled) { 
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
            }
            return;
        }
        // Вращаем голову таверки к врагу.
        LockOnTarget();


        if (isLaserWeapon)
        {
            Laser();
        }else {
            if (fireCountDown <= 0f) 
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }

            fireCountDown -= Time.deltaTime;
              }
    
        

    }

    // Отоброжение радиуса нашей таверки 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    // Метод поиска врагов 
    void UpdateTarget() 
    {
        // Ищем врагов в сцене по тегу и набиваем их в массив.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // Получаем минимальную дистанцию от таверки до цели(бесконечность).
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // Цикл с переборкой врагов. Если дистанция меньше нашей минимальной то даный объект и есть наша цель.
        foreach (GameObject enemy in enemies) 
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) 
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else 
        {
            target = null;
        }
    }

    void Shoot() 
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null) 
        {
            bullet.Seek(target);
        }
    }

    void LockOnTarget() 
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }


    void Laser() 
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPrc);

        if (!lineRenderer.enabled) { 
            lineRenderer.enabled = true;
            impactEffect.Play();
        }
      
        lineRenderer.SetPosition(0, firePoint.transform.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized * .6f;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
}
