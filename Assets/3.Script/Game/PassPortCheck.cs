using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passport
{
    public List<int> Tags;

    public Passport(List<int> tags)
    {
        Tags = tags;
    }
}

public class PassPortCheck : MonoBehaviour
{
    // Method to simulate retrieving passports
    List<Passport> RetrievePassports()
    {
        List<Passport> passports = new List<Passport>();

        for (int i = 0; i < 5; i++)
        {
            passports.Add(new Passport(GetRandomTags()));
        }

        return passports;
    }

    // Method to get random tags
    List<int> GetRandomTags()
    {
        List<int> tags = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            tags.Add(Random.Range(1, 6)); // Assuming tags are integers from 1 to 5
        }

        return tags;
    }

    // Method to check if any passport has tag 1
    bool CheckPassportsForTag1(List<Passport> passports)
    {
        foreach (var passport in passports)
        {
            if (passport.Tags.Contains(1))
            {
                return true;
            }
        }

        return false;
    }

    void Start()
    {
        List<Passport> passports = RetrievePassports();
        bool result = CheckPassportsForTag1(passports);

        Debug.Log("Any passport with tag 1: " + result);
    }
}
