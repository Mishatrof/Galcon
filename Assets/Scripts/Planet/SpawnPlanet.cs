using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanet : MonoBehaviour
{
    public GameObject PlanetPrefab;

    [SerializeField] private Camera cam;
    [SerializeField] private PlanetScriptable planetconf;
    [SerializeField] private GameManager manager;
    private void Awake()
    {
        Spawn(planetconf.CountPlanet);
    }
    public void Spawn(int Count)
    {

        for (int i = 0; i < Count; i++)
        {
            var  Go = Instantiate(PlanetPrefab, new Vector2(Random.Range(-cam.orthographicSize + 1, cam.orthographicSize - 1), Random.Range(-cam.orthographicSize + 1, cam.orthographicSize - 1)), Quaternion.identity);
            GameManager.AllPlanet.Add(Go);
            if (GameManager.AllPlanet.Count > 1)
            {
                if (!CheckDistance(Go))
                {
                    GameManager.AllPlanet.Remove(Go);
                    Destroy(Go);
                    Count++; //если была удалена планета, то создаем еще одну
                }
            }
        }

        manager.StartCoroutine(manager.ArmyUp());
    }
    bool CheckDistance(GameObject Go) //провреяем дистанцию между планетами
    {
        foreach (var item in GameManager.AllPlanet)
        {
            if (item != Go)
            {
                var dist = Vector2.Distance(Go.transform.position, item.transform.position);
                if (dist < 2)
                {
                    return false;

                }
            }
          
        }
        return true;
    }
}
