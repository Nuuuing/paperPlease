using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassportDateT
{
    public string name;
    public string gender;
    public string city;
    public string serialCode;
    public CountryC country;
    public string endDate;
    public int picNum;
}

public class PassportCorrControll : MonoBehaviour
{
    private PassportControll passC;
    private PassportDataControll passData;
    private PersonIntrControll person;

    private void Awake()
    {
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out passC);
        GameObject.FindObjectOfType<PassportDataControll>().TryGetComponent(out passData);
        GameObject.FindObjectOfType<PersonIntrControll>().TryGetComponent(out person);
    }

    private bool checkInCorrect()
    {
        float randomValue = Random.Range(0f, 1f);
        return randomValue <= 0.2f ? true : false;
    }

    public void settingPassData()
    {
        if (!passC.setPass)
        {
            CountryC country = passData.getRandomCountry();
            string cityName = passData.getRandomCity(country.type).name;
            string name = passData.getRandomPersonName().name;
            string endDate = getEndDateRandom();
            string serialCode = getSerialRandom();
            string gender = person.personT.type;

            //틀린정보 -> city string , endDate - string, gender - string, picSprite

            passC.passCorrData.name = name;
            passC.passCorrData.gender = gender;
            passC.passCorrData.city = cityName;
            passC.passCorrData.serialCode = serialCode;
            passC.passCorrData.country = country;
            passC.passCorrData.endDate = endDate;
            passC.passCorrData.picNum = person.personT.number;

            bool inCorr = checkInCorrect();
            if (inCorr)
            {
                settIncorrInfo(country.type, cityName, gender);
            }
            else
            {
                passC.isInCorr = 0;
            }
            passC.setPass = true;
        }
    }

    private void settIncorrInfo(int countryNum, string cityName, string gender)
    {
        int randomIndex = Random.Range(0, 4);
        //0 : city , 1: endDate, 2: gender , 3: pic
        if (randomIndex == 0)
        {
            passC.isInCorr = 1;
            string incorrCity = passData.getIncorrRandomCity(countryNum, cityName).name;
            passC.incorrData = incorrCity;
        }
        else if (randomIndex == 1)
        {
            passC.isInCorr = 2;
            string incorrEndDate = getIncorrEndDateRandom();
            passC.incorrData = incorrEndDate;
        }
        else if (randomIndex == 2)
        {
            passC.isInCorr = 3;
            string incorrGender;
            if (gender.Equals("MALE"))
            {
                incorrGender = "FEMAIL";
            }
            else
            {
                incorrGender = "MALE";
            }
            passC.incorrData = incorrGender;
        }
        else
        {
            passC.isInCorr = 4;
            int picNum;
            while (true)
            {
                picNum = Random.Range(0, 15);
                if (picNum == person.personT.number)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            passC.incorrPicNum = picNum;
        }
    }

    private string getEndDateRandom()
    {
        int randomYear;
        int randomMonth;
        int randomDay;

        while (true)
        {
            //기준일자 - 82.11.23
            randomYear = Random.Range(1982, 1986);
            randomMonth = Random.Range(1, 13);
            randomDay = Random.Range(1, 32);

            if (randomYear == 1982)
            {
                if (randomMonth < 10)
                {
                    continue;
                }
                else if (randomMonth == 11 && randomDay < 23)
                {
                    continue;
                }
                else
                    break;
            }
            else
                break;
        }
        return randomYear + "-" + randomMonth + "-" + randomDay;
    }

    private string getIncorrEndDateRandom()
    {
        //기준일자 - 82.11.23
        int randomYear;
        int randomMonth;
        int randomDay;

        while (true)
        {
            //기준일자 - 82.11.23
            randomYear = Random.Range(1970, 1983);
            randomMonth = Random.Range(1, 13);
            randomDay = Random.Range(1, 32);

            if (randomYear == 1982)
            {
                if (randomMonth == 11)
                {
                    if (randomDay >= 23)
                    {
                        continue;
                    }
                    else
                        break;
                }
                else
                    break;
            }
            else
                break;
        }

        return randomYear + "-" + randomMonth + "-" + randomDay;
    }

    private string getSerialRandom()
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int length = 5;

        string part1 = GenerateRandomString(alphabet, length);
        string part2 = GenerateRandomString(alphabet, length);

        return part1 + "-" + part2;
    }

    private string GenerateRandomString(string characters, int length)
    {
        System.Text.StringBuilder result = new System.Text.StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            int randomIndex = Random.Range(0, characters.Length);
            result.Append(characters[randomIndex]);
        }
        return result.ToString();
    }
}