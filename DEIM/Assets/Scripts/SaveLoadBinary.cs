using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;        //intPut outPut
using UnityEngine;

public class SaveLoadBinary : MonoBehaviour
{
    public string fileName = "text.bin";     //puede no tener nada dentras
    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.persistentDataPath + "\\" + fileName;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Save();
        }  
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Load();             
        }
    }

    void Save()
    {
        BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Create));  //Flujo de archivos , FileMode.Create si hay archivo se abre si no se crea
        bw.Flush();                      //este es para limpiar el codigo para que no tenga kk
        bw.Write(transform.position.x);
        bw.Write(transform.position.y);
        bw.Write(transform.position.z);
        bw.Flush();
        bw.Close();     
    }
    void Load()
    {

        if (!File.Exists(fileName))
        {
            return;
        }

        BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open));
        try
        {
            float x = br.ReadSingle();   // lee 8 bits
            float y = br.ReadSingle();
            float z = br.ReadSingle();           
            transform.position = new Vector3(x, y, z);
        }
        catch (System.Exception e)        //  como no seguarda info en ningun servidor, guardamos en LOCAL, no tenemos control sobre el archivo del usuario.
        {                                 // NOS aseguramos de detectar excepciones (errores) mientras se ejecuta y si algo va mal tenerlo controlado, sacar al topo de AC   
            Debug.Log(e.Message);
        }
        br.Close();
    }
}
