using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex = 0;
    private Enemy enemy;

    private void Start()
    {
        // Выбираем нулевой элемент в массиве точек
        target = Waypoints.waypointsPosition[0];
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        // Вычисляем направление и передвигаем наш объект по заданному напрвлению
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        // Если расстояние между двумя точками меньше чем 0.2 вызываем метод для получения слудующей точки.
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint()
    {
        if (wavePointIndex >= Waypoints.waypointsPosition.Length - 1)
        {
            Destroy(this.gameObject);
            enemy.BaseDamage();
            return;
        }
        wavePointIndex++;
        target = Waypoints.waypointsPosition[wavePointIndex];
    }
}
