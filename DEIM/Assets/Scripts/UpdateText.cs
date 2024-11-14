using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variable;
    
    private TMP_Text textComponent;
    private int points;
    private int lifes;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();        
    }

    // Update is called once per frame
    void Update()
    {
        //textComponent.text = "" + GameManager.instance.GetPoints();
        textComponent.text = "" + GameManager.instance.GetLifes();

        //if (points != GameManager.instance.GetPoints())
        //{
        //    Fade();         
        //}
        //points = GameManager.instance.GetPoints();
        

    }

    //public void Fade()
    //{
    //    StartCoroutine(FadeOut());
    //}

    //IEnumerator FadeOut()
    //{
    //    Color color = textComponent.color;                                         //guarda color 
    //    for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)               //disminyte alpha para que sea cada vez mas transparente
    //    {
    //        color.a = alpha;
    //        textComponent.color = color;
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //    StartCoroutine(FadeIn());
    //}
    //IEnumerator FadeIn()
    //{
    //    Color color = textComponent.color;
    //    for (float alpha = 0.0f; alpha <= 1; alpha += 0.01f)
    //    {
    //        color.a = alpha;
    //        textComponent.color = color;
    //        yield return new WaitForSeconds(0.01f);
    //    }

    //}
}
