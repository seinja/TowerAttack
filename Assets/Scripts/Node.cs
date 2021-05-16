using UnityEngine;

public class Node : MonoBehaviour
{

    // Цвета для индикации действий с клеткой
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    private BuildManager buildManager;
    public Color notEnoughtMoney;


    // Офсет чтобы таверка не закапывалась в клетку
    public Vector3 offset;

    // Сама турель для постройки
    public GameObject turret;


    // Получаем рендерер и устанавливаем стандарный цвет, меняем ывета при наведении в двух последующих методах
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseEnter()
    {
        
        if (!buildManager.CanBuild) return;


        rend.material.color = hoverColor;



    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }


    // При нажатии на клетку проверяем есть ли там таверка, если есть не строим, если нет, строим.
    private void OnMouseDown()
    {
        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else 
        {
            rend.material.color = notEnoughtMoney;
        }

        if (turret != null) { Debug.Log("We cant build here!"); return; }

        buildManager.BuildTurret(this);

    }

    public Vector3 GetNodePosition() 
    {
        return transform.position + offset;
    }
}
