using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public delegate void EndGame();
    public static event EndGame endGame;

    public static List<GameObject> AllPlanet = new List<GameObject>();
    public static List<PlanetConfig> MyPlanet = new List<PlanetConfig>();
    public static List<PlanetConfig> EnemyPlanet = new List<PlanetConfig>();

   
    public static PlanetConfig currentPlanet; // Текущая выбранная планета

    public static GameManager instance = null;


    [Header("Скрипты")]
    [SerializeField] private PlanetScriptable planetConf;
    [SerializeField] private SetTextOnPlanet setTextOnPlanet;
   


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


        Init();
        TakeMyPlanet();
        TakeEnemyPlanet();

        endGame += TheEndGame;
    }

 

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
                CheckRayCast();
    }
    void Init()
    {
        setTextOnPlanet.SetText(AllPlanet); //Подставляем текст информации на каждую планету\
        BotSystem.instance.takePlanet += TakeEnemyPlanet;
    }
    void TakeMyPlanet()
    {
        MyPlanet.Add(AllPlanet[Random.Range(0, AllPlanet.Count)].GetComponent<PlanetConfig>());
        var planetside = MyPlanet[0].GetComponent<PlanetSide>();

        planetside.side = PlanetSide.Side.Green;
        planetside.ChangeColor(planetside.side);
    }
    private void TakeEnemyPlanet()
    {

            EnemyPlanet.Add(AllPlanet[Random.Range(0, AllPlanet.Count)].GetComponent<PlanetConfig>());
       
        
            var planetside = EnemyPlanet[0].GetComponent<PlanetSide>();

            planetside.side = PlanetSide.Side.Red;
            planetside.ChangeColor(planetside.side);
      
    }
    void CheckRayCast()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (!hit)
        {
            foreach (var item in MyPlanet)
            {
                item.ChooseObj.SetActive(false);
                currentPlanet = null;
            }
           
        }
     
    }

 
  public static void TheEndGame()
    {
        if (EnemyPlanet.Count == 0)
        {
            Debug.Log("EndGame");
       
        }
    }

  public IEnumerator ArmyUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / planetConf.SpawnArmyForSeconds );
            for (int i = 0; i < MyPlanet.Count; i++)
            {
                MyPlanet[i].AddArmy();
            }
            for (int i = 0; i < EnemyPlanet.Count; i++)
            {
                EnemyPlanet[i].AddArmy();
            }
          
        }
    }
   
  

}
