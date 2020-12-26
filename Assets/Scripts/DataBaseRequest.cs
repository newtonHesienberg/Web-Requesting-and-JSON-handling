using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DataBaseRequest : MonoBehaviour
{
    private string url = "https://api.openweathermap.org/data/2.5/weather?id=2172797&appid=64e5cec70d7d3a8d0b2a5631d883bf4d";
    public Text temp , pressure , humidity , windSpeed;


    public void GetWeatherInfo()
    {
        StartCoroutine(WeatherRequest());
    }

    IEnumerator WeatherRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var dataBase = JsonConvert.DeserializeObject<JsonClasses>(request.downloadHandler.text);

            temp.text = dataBase.main.temp.ToString();
            pressure.text = dataBase.main.pressure.ToString();
            humidity.text = dataBase.main.humidity.ToString();
            windSpeed.text = dataBase.wind.speed.ToString();

        }
    }
}
