using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeManager : MonoBehaviour
{
    public static NodeManager instance;
    Renderer rend;
    public GameObject turret;
    GameObject nodeTurret;

    void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
	}

    void OnMouseEnter()
    {
        rend.enabled = true;
        PlaySound.instance.Play(7, 0.2f, 2.5f);
    }

    void OnMouseExit()
    {
        rend.enabled = false;
    }

    void OnMouseDown()
    {
        PlaySound.instance.Play(2, 0.2f, 1);

        if (!NodeUI.instance.MouseOver() && NodeUI.instance.IsCanvasActive() && !EventSystem.current.IsPointerOverGameObject())
        {
            NodeUI.instance.SetActiveCanvas(false);
            Debug.Log("AG");
            return;
        }
        if(turret == null && !NodeUI.instance.IsCanvasActive())
        {
            NodeUI.instance.SetActiveCanvas(true);
            NodeUI.instance.SetTarget(this);
            BuildManager.instance.GetNode(this);
            NodeUI.instance.buyingPanel.SetActive(true);
            NodeUI.instance.sellingPanel.SetActive(false);
        }
        if(turret != null && !NodeUI.instance.IsCanvasActive())
        {
            NodeUI.instance.SetActiveCanvas(true);
            NodeUI.instance.SetTarget(this);
            BuildManager.instance.GetNode(this);
            NodeUI.instance.buyingPanel.SetActive(false);
            NodeUI.instance.sellingPanel.SetActive(true);
        }
    }

    public void buildTurret()
    {
        PlaySound.instance.Play(2, 0.2f, 1);

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        Instantiate(turretToBuild, transform.position, transform.rotation);
        turret = turretToBuild;
        nodeTurret = turretToBuild;
    }

    public void DestroyTurret()
    {
        List<GameObject> turretArray = new List<GameObject>();

        foreach (GameObject trigo in GameObject.FindGameObjectsWithTag("Trigo"))
        {
            turretArray.Add(trigo);
        }
        foreach (GameObject enredadera in GameObject.FindGameObjectsWithTag("Enredadera"))
        {
            turretArray.Add(enredadera);
        }
        foreach (GameObject sunflower in GameObject.FindGameObjectsWithTag("SunFlower"))
        {
            turretArray.Add(sunflower);
        }
        float closestDistance = Mathf.Infinity;
        GameObject nearestTurret = null;

        foreach (GameObject turret in turretArray)
        {
            float distanceToTurret = Vector2.Distance(transform.position, turret.transform.position);
            if (distanceToTurret < closestDistance)
            {
                closestDistance = distanceToTurret;
                nearestTurret = turret;
            }
        }

        if (nearestTurret != null && closestDistance <= 0.5f)
        {
            Destroy(nearestTurret);
            turret = null;
            NodeUI.instance.SetActiveCanvas(false);
        }
    }

    public void Boosted()
    {
        if(turret != null)
        {
            if(turret == BuildManager.instance.wheatPlant)
            {
                turret.GetComponent<Wheat>().Boost();
            }
            if (turret == BuildManager.instance.sunPlant)
            {
                turret.GetComponent<SunFlower>().Boost();
            }
            if (turret == BuildManager.instance.thornPlant)
            {
                turret.GetComponent<Enredadera>().Boost();
            }
        }
    }

}
