using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


class PassportC
{
    string name;
    string endDate;
    string birth;
    string gender;

    string country;
    string city;
    int serial;
}

[Serializable]
public class NameC
{
    public int key;
    public string name;
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
    public List<CountryC> country;
}

public class PassportDataControll : MonoBehaviour
{
    PortDataT portData;

    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("passportData");
        
        portData = JsonUtility.FromJson<PortDataT>(jsonFile.text);
    }

    public CountryC getRandomCountry()
    {
        int randomIndex = UnityEngine.Random.Range(0, portData.country.Count);
        return portData.country[randomIndex];
    }
}
