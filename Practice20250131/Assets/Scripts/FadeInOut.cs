using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField]
    Text text;

    [SerializeField]
    [Range(0f,1f)]
    float alpha = 0;
    bool IsAdd = true;
    Color color;
   
    void Start()
    {
        color = text.GetComponent<Text>().color;
        color.a = alpha;
       

        //StartCoroutine("FadeIn");
    }

    
   

    IEnumerator FadeIn()
    {
        while(alpha <= 255 && alpha >= 0)
        {
            if(alpha == 0)
            {
                IsAdd = true;
                alpha++;
            }
            else if(alpha == 255)
            {
                IsAdd = false;
                alpha--;
            }
            else if (IsAdd)
            {
                color.a = alpha;
                alpha++;
                
            }
            else if (!IsAdd)
            {
                color.a = alpha;
                alpha--;
                
            }
            yield return new WaitForSeconds(0.2f); 
            
        }


    }
}
