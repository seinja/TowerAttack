using UnityEngine;
using UnityEngine.UI;

public class NodeUIScript : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public Text updateCost;
    public Text sellCost;

    public void SetTarget(Node _target) 
    {
        target = _target;
        transform.position = target.GetNodePosition();

        if (!target.isUpgraded)
        {
            updateCost.text = _target.blueprint.upgradeCost + "$";
        }
        else 
        {
            updateCost.text = "MAX";
        }
        if (!target.isUpgraded)
        {
            sellCost.text = _target.blueprint.sellCost + "$";
        }
        else 
        {
            sellCost.text = _target.blueprint.sellCost+50+ "$";
        }
        
        ui.SetActive(true);
    }

    public void Hide() 
    {
        ui.SetActive(false);
    }

    public void Upgrade() 
    {
        target.Upgradeturret();
        BuildManager.instance.DeselectNote();
    }

    public void Sell() 
    {
        target.RemoveTurret();
        BuildManager.instance.DeselectNote();
    }
}
