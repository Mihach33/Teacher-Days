using System;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountryClicker : MonoBehaviour
{
    private String currentCountry = "";
    private List<GameObject> countries;
    private System.Random _random = new System.Random();
    [SerializeField] private TextMeshProUGUI countryName;
    private static CountryClicker _instance; 
    public static CountryClicker Instance => _instance;

    private void Awake()
    {
        _instance = this;
        countries = new List<GameObject>(GameObject.FindGameObjectsWithTag("Country"));
   
    }

    private void Start()
    {
        countryName.text = "Poland";
        //GetUnusedCountry();
    }

    public void CheckIfProperCountryClicked(GameObject country)
    {
        if (country.name.Equals(countryName.text))
        {
            GetUnusedCountry();
            country.GetComponent<Image>().color = new Color(0,255,0);
            Debug.Log("True");
        }
        else
        {
                var posVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(posVec);
                Debug.Log(country.name);
                country.GetComponent<Image>().color = new Color(255,0,0,255);
        }
    }

    private void GetUnusedCountry()
    {
        if (countryName.text == "")
        {
            int r = _random.Next(0, countries.Count);
            countryName.text = countries[r].name;
            countries.RemoveAt(r);
        }
    }
    
  
}