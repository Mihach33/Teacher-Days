using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountryClicker : MonoBehaviour
{
    private String currentCountry = "";
    [SerializeField]private List<GameObject> countries;
    private System.Random _random = new System.Random();
    [SerializeField] private TextMeshProUGUI countryName;

    private void Start()
    {
        countries = new List<GameObject>(GameObject.FindGameObjectsWithTag("Country"));
        GetUnusedCountry();
        currentCountry = "Ukraine";
    }

    public void CheckIfProperCountryClicked(GameObject country)
    {
        if (country.name == countryName.text)
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

    public void ClickOnCountry(string countryName)
    {
        Debug.Log(countryName);
    }
}