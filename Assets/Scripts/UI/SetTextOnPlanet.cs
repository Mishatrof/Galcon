using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public  class SetTextOnPlanet : MonoBehaviour
{
    public Canvas canvas;
    public  void SetText(List<GameObject> planets)
    {
        int count = planets.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject CurrentText = Instantiate(Resources.Load("UiTextPrefab", typeof(GameObject)) as GameObject, transform.position, Quaternion.identity);
            CurrentText.transform.SetParent(canvas.transform);
            CurrentText.transform.position = planets[i].transform.position;
            planets[i].GetComponent<PlanetConfig>().TextArmy = CurrentText.GetComponent<TextMeshProUGUI>();
        }
    }

}
