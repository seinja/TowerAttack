using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurrentBlueprint standartTurret;
    public TurrentBlueprint missleLauncher;
    public TurrentBlueprint laserTurret;

    BuildManager buildManager;

    void Start() 
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandartTurret() 
    {
        Debug.Log("Buy standart tuuret");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissleTurret()
    {
        Debug.Log("Buy standart tuuret");
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("Buy standart tuuret");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
