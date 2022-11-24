using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    [SerializeField] private int healthPoint;
    [SerializeField] private Image[] _images;
    private Boolean playRedAnimation = false;
    private Boolean playRedReverseAnimation = false;
    private Boolean playGreenAnimation = false;

    private Boolean redAnimationPlayed = false;
    private float animationTime = 10000f;
    private float transpValue = 0f;

    private void Awake()
    {
        _instance = this;
        countries = new List<GameObject>(GameObject.FindGameObjectsWithTag("Country"));
    }


    private void Start()
    {
        GetUnusedCountry();
        healthPoint = 0;
    }


    private void Update()
    {
        if (playRedAnimation)
        {
            RedAnimationTransition();
        }

        if (playGreenAnimation)
        {
            GreenAnimationTransition();
        }

        if (playRedReverseAnimation)
        {
            RedAnimationReverseTransition();
        }
    }

    private void GreenAnimationTransition()
    {
        if (transpValue <= 1f)
        {
            transpValue += 0.1f;
            var currentColor = currentCountryObject.GetComponent<Image>().color;
            currentCountryObject.GetComponent<Image>().color =
                new Color(currentColor.r, currentColor.g, currentColor.b, transpValue);
        }
        else
        {
            playGreenAnimation = false;
            transpValue = 0f;
        }
    }

    private void RedAnimationTransition()
    {
        if (transpValue <= 1f)
        {
            transpValue += 0.11f;
            var currentColor = currentCountryObject.GetComponent<Image>().color;
            currentCountryObject.GetComponent<Image>().color =
                new Color(currentColor.r, currentColor.g, currentColor.b, transpValue);
        }
        else
        {
            playRedAnimation = false;
            playRedReverseAnimation = true;
        }
    }

    private void RedAnimationReverseTransition()
    {
        if (transpValue >= 0f)
        {
            transpValue -= 0.11f;
            var currentColor = currentCountryObject.GetComponent<Image>().color;
            currentCountryObject.GetComponent<Image>().color =
                new Color(currentColor.r, currentColor.g, currentColor.b, transpValue);
        }
        else
        {
            transpValue = 0f;
            playRedReverseAnimation = false;
        }
    }

    public void CheckIfProperCountryClicked(GameObject country)
    {
        currentCountryObject = country;
        if (country.name.Equals(countryName.text))
        {
            GetUnusedCountry();

            country.GetComponent<Image>().color = new Color(0, 255, 0, 0);
            playGreenAnimation = true;
        }
        else
        {
            Debug.Log(country.name);
            country.GetComponent<Image>().color = new Color(255, 0, 0, 0);
            playRedAnimation = true;
            PlusLosePoint();
        }
    }

    private void PlusLosePoint()
    {
        healthPoint++;
        _images[healthPoint].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        // if (GameOver)
        // {
        //     GameOver
        // }
    }

    private void GetUnusedCountry()
    {
        int r = _random.Next(0, countries.Count);
        Debug.Log(r);
        countryName.text = countries[r].name;
        countries.RemoveAt(r);
    }
}