using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameData
{

}
public class LoadMenu : MonoBehaviour
{
    private string filePath;
    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "savefile.json");
    }

    //public void SaveData(GameData data)
    //{
    //    string json = JsonUtility.ToJson(data);
    //    File.WriteAllText(filePath, json);
    //}

    public bool checkGameData()
    {
        if (File.Exists(filePath))
            return true;
        else
            return false;
    }

    public void goGameScene()
    {
        if(checkGameData())
        {
            //����� ����
            SceneManager.LoadScene("Game");
        }
        else
        {
            //�ű� ���ӽ� ���� ���丮 ��Ʈ�� ����
            SceneManager.LoadScene("NewGameIntro");
        }
    }

    //public GameData LoadData()
    //{
    //    if (File.Exists(filePath))
    //    {
    //        //string json = File.ReadAllText(filePath);
    //        //return JsonUtility.FromJson<GameData>(json);
    //        //������ ����
    //    }
    //    else
    //    {

    //    }
    //    return new GameData(); // Return default data if no save file found
    //}
}
