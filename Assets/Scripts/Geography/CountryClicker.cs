using System;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountryClicker : MonoBehaviour
{
    private String currentCountryName;
    private GameObject currentCountryObject;
    private List<GameObject> countries;
    private System.Random _random = new System.Random();
    [SerializeField] private TextMeshProUGUI countryName;
    private static CountryClicker _instance; 
    public static CountryClicker Instance => _instance;

    private Boolean playRedAnimation = false;
    private Boolean playGreenAnimation = false;

    private Boolean redAnimationPlayed = false;

    private void Awake()
    {
        _instance = this;
        countries = new List<GameObject>(GameObject.FindGameObjectsWithTag("Country"));
   
    }

    private void Start()
    {
        GetUnusedCountry();
    }


    private void Update()
    {
        if (playRedAnimation)
        {
            RedAnimationTransition();
        }
    }

    private void RedAnimationTransition()
    {
        
    }

    public void CheckIfProperCountryClicked(GameObject country)
    {
        if (country.name.Equals(countryName.text))
        {
            GetUnusedCountry();
            country.GetComponent<Image>().color = new Color(0,255,0, 255);
            Debug.Log("True");
        }
        else
        {
            currentCountryObject = country;
            Debug.Log(country.name);
            playRedAnimation = true;
            country.GetComponent<Image>().color = new Color(255,0,0,255);
        }
    }

    private void GetUnusedCountry()
    { 
        int r = _random.Next(0, countries.Count);
        Debug.Log(r);
        countryName.text = countries[r].name;
        countries.RemoveAt(r);
    }
    
  
}