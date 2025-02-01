using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField]
    Image panel;

    float alpha = 1;
   
   
    void Start()
    {
       

        StartCoroutine("FadeOut");
    }

    
   

    IEnumerator FadeIn()
    {
        while(alpha <= 1.0f)
        {
            panel.color = new Color(145/255f, 27/255f, 30/255f, alpha);
            alpha += 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
        //if(alpha > 1.0f)
        //{
        //    StartCoroutine("FadeOut");
        //}
        


    }

    IEnumerator FadeOut()
    {
        while (alpha >= 0)
        {
            panel.color = new Color(0, 0, 0, alpha);
            alpha -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
        //if (alpha < 0)
        //{
        //    StartCoroutine("FadeIn");
        //}
        

    }
}
