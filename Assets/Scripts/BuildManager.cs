using UnityEngine;

public class BuildManager : MonoBehaviour
{

    
    public static BuildManager instance;
    private TurrentBlueprint turretToBuild;

    public GameObject standartTurretPrefab;
    public GameObject laserTurretPrefab;
    public GameObject misleTurretPrefab;
    public GameObject buildEffect;


    // Используем паттерн Синглтон т.к нужен только один BuildManager
    private void Awake()
    {

        if (instance != null) { Debug.Log("More than one Build Manager"); }
        instance = this;


    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurrentBlueprint turret) 
    {
        turretToBuild = turret;
    }

    public void BuildTurret(Node node) 
    {
        if (PlayerStats.money < turretToBuild.cost) { Debug.Log("Low money"); return; }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetNodePosition(),Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetNodePosition(), Quaternion.identity);
        Destroy(effect, 1f);
    }

}
