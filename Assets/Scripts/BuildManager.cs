using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    GameObject turretToBuild;
    NodeManager node;

    public GameObject wheatPlant;
    public GameObject sunPlant;
    public GameObject thornPlant;
    public GameObject fiddle;
    public GameObject sprinkler;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public void GetNode(NodeManager _node)
    {
        node = _node;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void WheatPlantSelected()
    {
        if(Resources.instance.energy >= 25)
        {
            Resources.instance.energy -= 25;
            Resources.instance.ActualizeEnergy();
            turretToBuild = wheatPlant;
            NodeUI.instance.SetActiveCanvas(false);
            NodeUI.instance.onMouseOver = false;

            node.buildTurret();
        }
        else
        {
            PlaySound.instance.Play(0, 0.2f, 1);

        }
    }

    public void SunPlantSelected()
    {
        if(Resources.instance.energy >= 15)
        {
            Resources.instance.energy -= 15;
            Resources.instance.ActualizeEnergy();
            turretToBuild = sunPlant;
            NodeUI.instance.SetActiveCanvas(false);
            NodeUI.instance.onMouseOver = false;
            node.buildTurret();
        }
        else
        {
            PlaySound.instance.Play(0, 0.2f, 1);

        }
    }

    public void ThornPlantSelected()
    {
        if (Resources.instance.energy >= 70)
        {
            Resources.instance.energy -= 70;
            Resources.instance.ActualizeEnergy();
            turretToBuild = thornPlant;
            NodeUI.instance.SetActiveCanvas(false);
            NodeUI.instance.onMouseOver = false;

            node.buildTurret();
        }
        else
        {
            PlaySound.instance.Play(0, 0.2f, 1);

        }
    }

    public void FiddleSelected()
    {
        if (Resources.instance.money >= 50)
        {
            Resources.instance.money -= 50;
            Resources.instance.ActualizeMoney();
            turretToBuild = fiddle;
            NodeUI.instance.SetActiveCanvas(false);
            NodeUI.instance.onMouseOver = false;

            node.buildTurret();
        }
        else
        {
            PlaySound.instance.Play(0, 0.2f, 1);

        }
    }

    public void SprinklerSelected()
    {
        if (Resources.instance.money >= 200)
        {
            Resources.instance.money -= 200;
            Resources.instance.ActualizeMoney();
            turretToBuild = sprinkler;
            NodeUI.instance.SetActiveCanvas(false);
            NodeUI.instance.onMouseOver = false;

            node.buildTurret();
        }
        else
        {
            PlaySound.instance.Play(0, 0.2f, 1);

        }
    }

    public void Sell()
    {
        PlaySound.instance.Play(5, 0.2f, 1);

        if (node.turret == wheatPlant)
        {
            Resources.instance.energy += 10;
            Resources.instance.ActualizeEnergy();
            node.DestroyTurret();
        }
        if (node.turret == thornPlant)
        {
            Resources.instance.energy += 40;
            Resources.instance.ActualizeEnergy();
            node.DestroyTurret();
        }
        if (node.turret == sunPlant)
        {
            Resources.instance.energy += 5;
            Resources.instance.ActualizeEnergy();
            node.DestroyTurret();
        }
        if (node.turret == fiddle)
        {
            Resources.instance.money += 30;
            Resources.instance.ActualizeMoney();
            node.DestroyTurret();
        }
        if (node.turret == sprinkler)
        {
            Resources.instance.money += 100;
            Resources.instance.ActualizeMoney();
            node.DestroyTurret();
        }
    }
}
