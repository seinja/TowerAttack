using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    // Цвета для индикации действий с клеткой
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    private BuildManager buildManager;
    public Color notEnoughtMoney;
    public TurrentBlueprint blueprint;
    public bool isUpgraded = false;


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
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

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
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        if (turret != null) {
            buildManager.SelectNode(this);
            return; }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else 
        {
            rend.material.color = notEnoughtMoney;
        }

        if (!buildManager.CanBuild) { return; }

        BuildTurret(buildManager.GetTurretToBuild());

    }

    public Vector3 GetNodePosition() 
    {
        return transform.position + offset;
    }

    void BuildTurret(TurrentBlueprint _blueprint) 
    {
        if (PlayerStats.money < _blueprint.cost) { Debug.Log("Low money"); return; }

        PlayerStats.money -= _blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(_blueprint.prefab, this.GetNodePosition(), Quaternion.identity);
        turret = _turret;
        blueprint = _blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, this.GetNodePosition(), Quaternion.identity);
        Destroy(effect, 1f);
    }

    public void Upgradeturret() 
    {
        if (PlayerStats.money < blueprint.upgradeCost) { Debug.Log("Low money"); return; }

        PlayerStats.money -= blueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(blueprint.upgradedPrefab, this.GetNodePosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, this.GetNodePosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isUpgraded = true;
    }

    public void RemoveTurret() 
    {
        Destroy(turret);
        PlayerStats.money += blueprint.sellCost;
    }
}
