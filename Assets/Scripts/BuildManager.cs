﻿using UnityEngine;

public class BuildManager : MonoBehaviour
{

	public static BuildManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private TurrentBlueprint turretToBuild;
	private Node selectedNode;

	public NodeUIScript nodeUI;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

	public void SelectNode(Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTurretToBuild(TurrentBlueprint turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public TurrentBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}

}