using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using TMPro;

public class PlanetConfig : MonoBehaviour , IAdditionArmy
{
  

    public int CurrentArmy = 25;
    public GameObject ChooseObj;
    public TextMeshProUGUI TextArmy;
    public PlanetSide planetSide;

    public void AddArmy()
    {
        CurrentArmy++;
        TextArmy.text = ToString();
        
    }
    public void MinusArmy(ArmyConfiguration conf)
    {
        CurrentArmy--;
        if(CurrentArmy <= 0)
        {
            planetSide.Change(conf);
        }
        TextArmy.text = ToString();
    }


    public void OnMouseDown()
    {
        if (planetSide.side == PlanetSide.Side.Green)
        {

            ChooseObj.SetActive(true);
            GameManager.currentPlanet = this;
        }
    }
    public override string ToString() => string.Format("({0})", CurrentArmy);
 
  

 

   
  
}
