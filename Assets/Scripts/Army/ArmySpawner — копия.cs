using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmySpawner : MonoBehaviour, ISpawner
{
    public GameObject ArmyPrefab;

    [SerializeField] private PlanetConfig config;

    private void Start()
    {
        config = GetComponent<PlanetConfig>();
    }
    public void Spawn(Transform Target, PlanetConfig currentPlanet)
    {
        for (int i = 0; i < config.CurrentArmy / 2; i++)
        {
           var Go = Instantiate(ArmyPrefab, transform.position , Quaternion.identity);
            var conf = Go.GetComponent<ArmyConfiguration>();
            conf.SetDestinationArmy(Target);
            conf.myside = currentPlanet.planetSide;
            conf.myside.side = currentPlanet.planetSide.side;
        }
        config.CurrentArmy /= 2;
    }
}
