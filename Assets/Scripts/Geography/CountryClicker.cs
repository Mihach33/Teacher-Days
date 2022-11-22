using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        countryName.text = "Ukraine";
       // GetUnusedCountry();
    }

    public void CheckIfProperCountryClicked(GameObject country)
    {
        if (country.name.Equals(countryName.text))
        {
            GetUnusedCountry();
            Debug.Log("True");
        }
        else
        {
            Debug.Log("False");
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