using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    public int poolSize = 5;
    public GameObject personPrefab;
    public Transform parentTransform;

    private List<GameObject> personPool;
    private List<GameObject> activePersons;

    void Start()
    {
        // Initialize the pool
        personPool = new List<GameObject>();
        activePersons = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject person = Instantiate(personPrefab, parentTransform);
            person.SetActive(false);
            personPool.Add(person);
        }
    }

    public void SpawnPerson(Vector3 position)
    {
        GameObject person = GetPooledObject();
        if (person != null)
        {
            person.transform.position = position;
            person.SetActive(true);
            activePersons.Add(person);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in personPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // Optionally, expand the pool if needed
        GameObject newObj = Instantiate(personPrefab, parentTransform);
        newObj.SetActive(false);
        personPool.Add(newObj);
        return newObj;
    }

    public void ReleasePerson(GameObject person)
    {
        if (person != null)
        {
            person.SetActive(false);
            activePersons.Remove(person);
        }
    }

    public GameObject GetFirstInactivePerson()
    {
        foreach (GameObject person in personPool)
        {
            if (!person.activeInHierarchy)
            {
                return person;
            }
        }
        return null;
    }

    public List<GameObject> GetActivePersons()
    {
        return new List<GameObject>(activePersons);
    }
}