using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameManagerVariables { POINTS };
    public float initialPoints;
    
    private int points = 0;
    private List<string> hours;


    private void Awake()
    {

        //Singleton         //singleton accesible para cualquiera, solo existe una instancia  
        if (!instance)     // si instance no tiene informacion
        {
            instance = this;    // instance se asigna a este objet.                                 el gameManager querra crearse, si no hay otro antes este sera el principal
            DontDestroyOnLoad(gameObject);        //no se destruye con la carga de escenas 
            hours = new List<string>();
        }
        else
        {
            Destroy(gameObject);    //se destruye el  gameObject para que no  haya dos o mas gm en el juego
        }
    }
    void Start()
    {
        initialPoints = points;
    }
    private void Update()
    {
           
    }
    public int GetPoints()
    {
        return points;
    }
    public void AddPoints(int pointA)
    {
        points += pointA;
    }
    public List<string> GetTime()
    {
         return hours;
    }
    public void SetTime(List<string> value)
    {
        hours = value;
    }
}
