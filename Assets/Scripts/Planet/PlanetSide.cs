using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSide : MonoBehaviour, IChangeSide
{
  [SerializeField] private SpriteRenderer render;
    [SerializeField] private delegate void Remover();
    [SerializeField] private event Remover remover;
    public enum Side
    {
        Green,
        Red,
        Gray
    }
    public Side side;

    private void OnEnable()
    {
        remover += RemoveFromListPlanet;
    }
  
    public void Change(ArmyConfiguration currentArmy)
    {
        remover?.Invoke();
        if (currentArmy.myside.side == Side.Green)
        {
            side = Side.Green;
            ChangeColor(side);
            GameManager.MyPlanet.Add(gameObject.GetComponent<PlanetConfig>());
           
        }
        else
        {
            side = Side.Red;
            ChangeColor(side);
            GameManager.EnemyPlanet.Add(gameObject.GetComponent<PlanetConfig>());
           
        }



        GameManager.TheEndGame();

        Debug.Log($"{GameManager.EnemyPlanet.Count}");
    }

    void RemoveFromListPlanet()
    {
        if (side == Side.Red)
        {
            GameManager.EnemyPlanet.Remove(gameObject.GetComponent<PlanetConfig>());
        }
        else if (side == Side.Green)
        {
            GameManager.MyPlanet.Remove(gameObject.GetComponent<PlanetConfig>());

        }
    }
 
    public void ChangeColor(Side side)
    {
        switch (side)
        {
            case Side.Green:
                render.color = Color.blue;
                break;
            case Side.Red:
               render.color = Color.red;
                break;
        }
         


    }
}
