using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSystem : MonoBehaviour
{

    public delegate void TakePlanet();
    public event TakePlanet takePlanet;

    public static BotSystem instance = null;
    public float TimeAttack = 7f;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        takePlanet?.Invoke();
        StartCoroutine(Attack());
       
    }
  

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeAttack);
            var takeRndPlanet = GameManager.AllPlanet[Random.Range(0, GameManager.AllPlanet.Count)];
            var currentPlanet = GameManager.EnemyPlanet[Random.Range(0, GameManager.EnemyPlanet.Count)];
            if(currentPlanet.gameObject != takeRndPlanet)
                 currentPlanet.gameObject.GetComponent<ArmySpawner>().Spawn(takeRndPlanet.transform, currentPlanet);
        }
    }
}
