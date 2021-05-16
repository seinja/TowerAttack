using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Положения точек перемещения в массиве
    public static Transform[] waypointsPosition;

    void Awake()
    {
        //Инициализация массива длинной с количеством дочерних элементов
        waypointsPosition = new Transform[transform.childCount];



        for (int i = 0; i < waypointsPosition.Length; i++)
        {
            waypointsPosition[i] = transform.GetChild(i);
        }

    }
}
