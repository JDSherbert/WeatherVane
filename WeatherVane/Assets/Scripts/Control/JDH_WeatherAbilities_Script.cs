using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_WeatherAbilities_Script : MonoBehaviour
{
    [System.Serializable]
    public class WeatherData
    {
        public GameObject playerObject;
        public GameObject weatherOrigin;
        public Canvas weatherUICanvas;
        public Collider playerCollider;

        public bool hasSun, hasRain, hasSnow, hasThunder, hasHurricane, hasEarthquake, hasMeteor = false;



    }

    public WeatherData weatherData = new WeatherData();

    public void Start()
    {
        GetComponents();

    }

    public void FixedUpdate()
    {
        
    }

    public void GetComponents()
    {
        weatherData.playerObject = GameObject.FindWithTag("Player");
        weatherData.weatherUICanvas = GameObject.Find("UserInterface").GetComponent<Canvas>();
        weatherData.weatherOrigin = GameObject.Find("/Player/WeatherOrigin");
        weatherData.playerCollider = GetComponent<Collider>();
    }

    public void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "WeatherGene_Sun")
        {
            weatherData.hasSun = true;
            WeatherHandler();
        }
        if (collision.gameObject.tag == "WeatherGene_Rain")
        {
            weatherData.hasRain = true;
        }
        if (collision.gameObject.tag == "WeatherGene_Snow")
        {
            weatherData.hasSnow = true;
        }
        if (collision.gameObject.tag == "WeatherGene_Thunder")
        {
            weatherData.hasThunder = true;
        }
        if (collision.gameObject.tag == "WeatherGene_Earthquake")
        {
            weatherData.hasEarthquake = true;
        }
        if (collision.gameObject.tag == "WeatherGene_Hurricane")
        {
            weatherData.hasHurricane = true;
        }
        if (collision.gameObject.tag == "WeatherGene_Meteor")
        {
            weatherData.hasMeteor = true;
        }
    }

    public void WeatherHandler()
    {
        if(weatherData.hasSun == true)
        {
            GameObject.Find("/UserInterface/Canvas/Panel_WeatherPowers/Button_Sun").SetActive(true);
        }
    }

}
