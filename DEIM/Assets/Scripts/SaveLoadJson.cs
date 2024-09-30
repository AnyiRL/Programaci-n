using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]             // un objeto que es capaz de convertirse a un archivo en el formato json, binario y biceversa se le denomina un objeto SERIALIZABLE
struct PlayerData                 //es mas pequeño que una clase 
{
    public Vector3 position;                            
}

public class SaveLoadJson : MonoBehaviour
{
    public string fileName = "test.json";
    // Start is called before the first frame update
    void Start()
    {
        Load();
        fileName = Application.persistentDataPath + "\\" + fileName;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    Save();
        //}
        //else if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Load();
        //}
    }

    private void Save()
    {
        StreamWriter sw = new StreamWriter(fileName);
        
        PlayerData playerData = new PlayerData();       // instancio objeto 
        playerData.position = transform.position;       //rellenamos info
        sw.WriteLine(GameManager.instance.GetPoints());
        string json = JsonUtility.ToJson(playerData);    //pasar de objeto serializable a formato json 
        sw.WriteLine(json);

        sw.Close();
    }

    private void Load()
    {

        if (File.Exists(fileName))
        {
            StreamReader sr = new StreamReader(fileName);

            string json = sr.ReadToEnd();
            sr.Close();   //el sitio no influye mucho
            
            try
            {
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);     //no hace falta instanciar nuevo objeto porque ya se hace por dentro, pasa de json a objeto serializable
                transform.position = playerData.position;
            }
            catch (System.Exception e)
            {
                // sacar al topo de AC
                Debug.Log(e.Message);
            }
        }
    }
    private void OnDestroy()
    {
        Save();
    }
}
