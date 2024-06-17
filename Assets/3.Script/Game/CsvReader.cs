using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CsvReader : MonoBehaviour
{
    private Dictionary<int, string> roundInformation;
    void Start()
    {
        LoadCSV();
    }

    void LoadCSV()
    {
        roundInformation = new Dictionary<int, string>();
        TextAsset csvData = Resources.Load<TextAsset>("game_rounds");

        StringReader reader = new StringReader(csvData.text);
        bool header = true;

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            if (header)
            {
                header = false;
                continue;
            }

            string[] values = line.Split(',');
            int round = int.Parse(values[0]);
            string info = values[1];

            roundInformation.Add(round, info);
        }
    }

    public string GetRoundInformation(int round)
    {
        if (roundInformation.ContainsKey(round))
        {
            return roundInformation[round];
        }
        else
        {
            return "No information available for this round.";
        }
    }
}
