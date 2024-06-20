using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    public int poolSize = 10;
    public GameObject personPrefab;

    private List<GameObject> personPool;

    void Start()
    {
        // Initialize the pool
        personPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject person = Instantiate(personPrefab);
            person.SetActive(false);
            personPool.Add(person);
        }
    }

    public void SpawnPerson(Vector3 position)
    {
        GameObject person = GetPooledPerson();
        if (person != null)
        {
            person.transform.position = position;
            person.GetComponent<PersonIntrControll>();
            person.SetActive(true);
        }
    }
    private GameObject GetPooledPerson()
    {
        foreach (GameObject person in personPool)
        {
            if (!person.activeInHierarchy)
            {
                return person;
            }
        }
        return null; // If no inactive person found, return null
    }

    public void ReleasePerson(GameObject person)
    {
        person.SetActive(false);
    }
}
