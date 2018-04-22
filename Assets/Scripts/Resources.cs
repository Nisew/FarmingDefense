using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public static Resources instance;

    public int energy;
    int maxEnergy = 999;
    public int money;
    int maxMoney = 9999;
    public int score;
    public int lives;

    float counter;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject defeat;

    public int sprinklerCost;

    void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        energy = 100;
        money = 50;
        sprinklerCost = 200;
        lives = 3;
        ActualizeEnergy();
        ActualizeMoney();
        ActualizeScore();
        defeat.SetActive(false);
    }

    void Update()
    {
        counter += Time.deltaTime;

        if(counter >= 30)
        {
            counter = 0;
            energy += 10;
            ActualizeEnergy();
        }
    }

    public void ActualizeEnergy()
    {
        if (energy >= maxEnergy) energy = maxEnergy;
        GameObject.Find("EnergyText").GetComponent<Text>().text = "" + energy;
    }

    public void ActualizeMoney()
    {
        if (money >= maxMoney) money = maxMoney;

        GameObject.Find("MoneyText").GetComponent<Text>().text = "" + money;
    }

    public void ActualizeScore()
    {
        GameObject.Find("ScoreText").GetComponent<Text>().text = score + "pts.";
    }

    public void ActualizeLives()
    {
        if(lives == 2)
        {
            heart3.SetActive(false);
        }
        if(lives == 1)
        {
            heart2.SetActive(false);
        }
        if(lives == 0)
        {
            heart1.SetActive(false);
            defeat.SetActive(true);
            PlaySound.instance.Play(6, 0.5f, 0.5f);
        }
    }
}
