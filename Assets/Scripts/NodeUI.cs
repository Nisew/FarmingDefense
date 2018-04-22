using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public static NodeUI instance;
    public GameObject canvas;
    public GameObject sellingPanel;
    public GameObject buyingPanel;
    public GameObject wheatButton;

    public bool onMouseOver;

    void Awake()
    {
        instance = this;
        this.gameObject.SetActive(false);
    }

    NodeManager target;

    public void SetTarget(NodeManager node)
    {
        this.transform.position = new Vector3(node.transform.position.x, node.transform.position.y, node.transform.position.z - 3);
        target = node;
    }

    void OnMouseEnter()
    {
        onMouseOver = true;
    }

    void OnMouseExit()
    {
        onMouseOver = false;
    }

    public void SetActiveCanvas(bool bul)
    {
        if (bul)
        {
            this.gameObject.SetActive(true);
        }
        else this.gameObject.SetActive(false);
    }

    public bool IsCanvasActive()
    {
        bool buleana;

        if (this.gameObject.activeInHierarchy) buleana = true;
        else buleana = false;

        return buleana;
    }

    public bool MouseOver()
    {
        return onMouseOver;
    }
}
