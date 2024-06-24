using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class NameC
{
    public int key;
    public string name;
}

[Serializable]
public class GenderC
{
    public int number;
    public string type;
}

[Serializable]
public class CityC
{
    public int type;
    public string name;
}

[Serializable]
public class CountryC
{
    public int type;
    public string name;
}

[Serializable]
public class PortDataT
{
    public List<NameC> name;
    public List<CityC> city;
    public List<GenderC> gender;
    public List<CountryC> country;
}

public class PassportDataControll : MonoBehaviour
{
    PortDataT portData;

    void Awake()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("passportData");
        portData = JsonUtility.FromJson<PortDataT>(jsonFile.text);
    }

    public CountryC getRandomCountry()
    {
        int randomIndex = UnityEngine.Random.Range(0, portData.country.Count);
        return portData.country[randomIndex];
    }

    public CityC getRandomCity(int countryNum)
    {
        List<CityC> cities = portData.city.FindAll(city => city.type == countryNum);

        // 필터링된 city 리스트에서 랜덤으로 선택
        int randomIndex = UnityEngine.Random.Range(0, cities.Count);
        return cities[randomIndex];
    }
    public CityC getIncorrRandomCity(int countryNum ,string corrCity)
    {
        List<CityC> cities = portData.city.FindAll(city => city.type != countryNum);

        int randomIndex;
        while(true)
        {
            randomIndex = UnityEngine.Random.Range(0, cities.Count);
            if(cities[randomIndex].Equals(corrCity))
            {
                continue;
            }
            else
            {
                break;
            }
        }
        return cities[randomIndex];
    }

    public GenderC getRandomPersonNumber()
    {
        int randomIndex = UnityEngine.Random.Range(0, portData.gender.Count);
        return portData.gender[randomIndex];
    }

    public NameC getRandomPersonName()
    {
        int randomIndex = UnityEngine.Random.Range(0, portData.name.Count);
        return portData.name[randomIndex];
    }
}
