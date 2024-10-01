using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;


public class SaveLoadTxt : MonoBehaviour
{
    public string fileName = "text.txt";
    private DateTime thisDay;
    List<DateTime> tiempo = new List<DateTime>();
    // Start is called before the first frame update
    void Start()
    {
        Load();                          
    }

    // Update is called once per frame
    void Update()
    {
        thisDay = DateTime.Now;
        //    if (Input.GetKeyDown(KeyCode.G))
        //    {
        //        Save();
        //    }  
        //    else if (Input.GetKeyDown(KeyCode.L))
        //    {
        //        Load();             
        //    }
    }

    private void Save()
    {
        // guardar
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "\\" + fileName);         //8bits   append true mantiene la informacion y pasa a la siguiente linea a escribir, el false lo borra e inicia a escribir desde 0
        sw.WriteLine(transform.position.x);
        sw.WriteLine(transform.position.y);
        sw.WriteLine(transform.position.z);
        sw.WriteLine(GameManager.instance.GetPoints());
        sw.WriteLine(thisDay.ToString("g"));            //tiempo  5/3/2012 12:00 AM
        tiempo.Add(thisDay);
        //if (tiempo.Count != 0)
        //{
        //    sw.WriteLine(tiempo);
        //}
        foreach (DateTime time in tiempo)
        {
            sw.WriteLine(time);
        }
                                                             
        sw.Close();        // es importante cerrar el archivo, no se guarda si no se cierra
        
    }

    private void Load()
    {
        //cargar informacion 
        if (File.Exists(Application.persistentDataPath + "\\" + fileName))     //para que sea mas dificil de acceder para el usuario
        {
            try
            {
                StreamReader sr = new StreamReader(Application.persistentDataPath + "\\" + fileName);
                //sr.ReadLine();  // la primera linea no es importante, movemos el cursor del archivo a la siguiente linea
                //sr.ReadLine();  // volvemos a pasar a la siguiente

                float x = float.Parse(sr.ReadLine());        //parse cambia string a float 
                float y = float.Parse(sr.ReadLine());
                float z = float.Parse(sr.ReadLine());
                int point = int.Parse(sr.ReadLine());
                DateTime time = DateTime.Parse(sr.ReadLine());
                sr.ReadLine();
                transform.position = new Vector3(x, y, z);  // establecemos la posicion en el gameObject
                //tiempo.Add(time);
                
                sr.Close();     // puede corromper el archivo si no se cierra
                GameManager.instance.AddPoints(point);
                //GameManager.instance.GetTime(tiempo.Add(time));
            }
            catch (System.Exception e)        //  como no seguarda info en ningun servidor, guardamos en LOCAL, no tenemos control sobre el archivo del usuario.
            {                                 // NOS aseguramos de detectar excepciones (errores) mientras se ejecuta y si algo va mal tenerlo controlado, sacar al topo de AC   
                Debug.Log(e.Message);
            }
        }
    }

    private void OnDestroy()
    {
        Save();
    }
}
// widows + R , app data, localLow, defaultCompany , nombre del proyecto