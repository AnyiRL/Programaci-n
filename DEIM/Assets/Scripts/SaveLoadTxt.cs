using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadTxt : MonoBehaviour
{
    public string fileName = "text.txt";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    private void Save()
    {
        // guardar
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "\\" + fileName);         //8bits   append true mantiene la informacion y pasa a la siguiente linea a escribir, el false lo borra e inicia a escribir desde 0
        sw.WriteLine("archivo guardado");
        sw.WriteLine(Random.Range(0, 100));
        sw.WriteLine(transform.position.x);
        sw.WriteLine(transform.position.y);
        sw.WriteLine(transform.position.z);
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
                sr.ReadLine();  // la primera linea no es importante, movemos el cursor del archivo a la siguiente linea
                sr.ReadLine();  // volvemos a pasar a la siguiente
                float x = float.Parse(sr.ReadLine());        //parse cambia string a float 
                float y = float.Parse(sr.ReadLine());
                float z = float.Parse(sr.ReadLine());

                transform.position = new Vector3(x, y, z);  // establecemos la posicion en el gameObject

                sr.Close();     // puede corromper el archivo si no se cierra
                
            }
            catch (System.Exception e)        //  como no seguarda info en ningun servidor, guardamos en LOCAL, no tenemos control sobre el archivo del usuario.
            {                                 // NOS aseguramos de detectar excepciones (errores) mientras se ejecuta y si algo va mal tenerlo controlado,    
                                              //sacar al topo de AC
                Debug.Log(e.Message);
            }
        }
    }
}
// widows + R , app data, localLow, defaultCompany , nombre del proyecto