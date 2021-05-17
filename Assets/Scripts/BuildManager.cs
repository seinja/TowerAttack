using UnityEngine;

public class BuildManager : MonoBehaviour
{

    
    public static BuildManager instance;
    private TurrentBlueprint turretToBuild;
    private Node selectedNode;

    public GameObject standartTurretPrefab;
    public GameObject laserTurretPrefab;
    public GameObject misleTurretPrefab;
    public GameObject buildEffect;
    public NodeUIScript nodeUI;


    // Используем паттерн Синглтон т.к нужен только один BuildManager
    private void Awake()
    {

        if (instance != null) { Debug.Log("More than one Build Manager"); }
        instance = this;


    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }


    public void SelectNode(Node node)
    { 

        if(selectedNode == node) 
        {
            DeselectNote();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void SelectTurretToBuild(TurrentBlueprint turret) 
    {
        turretToBuild = turret;
        DeselectNote();
    }

    public TurrentBlueprint GetTurettToBuild() { return turretToBuild; }

    public void DeselectNote() 
    {
        selectedNode = null;
        nodeUI.Hide();
    }

}
