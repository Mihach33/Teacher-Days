using System;
using System.Collections.Generic;
using UnityEngine;

public class CountryClicker : MonoBehaviour
{
    private String currentCountry = "";
    private List<GameObject> countries;
    private System.Random _random = new System.Random();

    private void Start()
    {
        countries = new List<GameObject>(GameObject.FindGameObjectsWithTag("Country"));
        // GetUnusedCountry();
        currentCountry = "Ukraine";
    }

    public void CheckIfProperCountryClicked(GameObject country)
    {
        var material = country.GetComponent<MeshRenderer>().material;
        if (country.name == currentCountry)
        {
            currentCountry = "";
            material.SetColor("_Color", Color.green);
        }
        else
        {
            material.SetColor("_Color", Color.red);
        }
    }

    private void GetUnusedCountry()
    {
        if (currentCountry == "")
        {
            int r = _random.Next(0, countries.Count);
            currentCountry = countries[r].name;
            countries.RemoveAt(r);
        }
    }

    public void ClickOnCountry(string countryName)
    {
        Debug.Log(countryName);
    }
}