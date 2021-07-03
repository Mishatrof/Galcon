using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]  private Camera cam;
    [SerializeField]  private ArmySpawner armySpawner;
    Vector3 StartPos;
    Vector3 endPos;
    Vector3 mousePos;
    Vector3 mouseDir;
    LineRenderer line;


    private void Start()
    {
        line = GetComponent<LineRenderer>();

    }

    private void Update()
    {
        CreateLine();
    }

    void CreateLine()
    {
        if (GameManager.currentPlanet == null)
        {
            line.enabled = false;

        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0;
        mouseDir = mouseDir.normalized;

        if (GameManager.currentPlanet != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                line.enabled = true;
                armySpawner = GameManager.currentPlanet.GetComponent<ArmySpawner>();
            }
            if (Input.GetMouseButton(0))
            {
                StartPos = GameManager.currentPlanet.gameObject.transform.position;
                StartPos.z = 0;
                line.SetPosition(0, StartPos);
                endPos = mousePos;
                endPos.z = 0;
                line.SetPosition(1, endPos);

            }
            if (Input.GetMouseButtonUp(0))
            {
                CastRay(); // проверяем отпустили ли мы кнопку над объектом 
                line.enabled = false;

            }
        }
    }
    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            if(hit.collider != GameManager.currentPlanet)
            {
            
                armySpawner.Spawn(hit.collider.transform, GameManager.currentPlanet);
            }
        }
    }
}
