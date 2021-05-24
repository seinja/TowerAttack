using UnityEngine;
using UnityEngine.UI;

public class NodeUIScript : MonoBehaviour
{
    private Node currentTurret;
    public GameObject ui;
    public Text updateCost;
    public Text sellCost;

    public void SetTarget(Node target) 
    {
        currentTurret = target;
        transform.position = currentTurret.GetNodePosition();

        if (!currentTurret.isUpgraded)
        {
            updateCost.text = target.blueprint.upgradeCost + "$";
        }
        else 
        {
            updateCost.text = "MAX";
        }
        if (!currentTurret.isUpgraded)
        {
            sellCost.text = target.blueprint.sellCost + "$";
        }
        else 
        {
            sellCost.text = target.blueprint.sellCost+50+ "$";
        }
        
        ui.SetActive(true);
    }

    public void Hide() 
    {
        ui.SetActive(false);
    }

    public void Upgrade() 
    {
        currentTurret.Upgradeturret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell() 
    {
        currentTurret.RemoveTurret();
        BuildManager.instance.DeselectNode();
    }
}
