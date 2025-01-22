using System;
using UnityEngine;


[Flags]
public enum RAINBOW
{
    None = 0,
    빨 = 1 << 0, 
    주 = 1 << 1, 
    노 = 1 << 2, 
    초 = 1 << 3, 
    파 = 1 << 4, 
    남 = 1 << 5, 
    보 = 1 << 6
}

[AddComponentMenu("JBY/Sample01")]
public class Sample01 : MonoBehaviour
{
    [Tooltip("체크되면 점프가능")]
    public bool jumpable;

    public string[] fruits;

    public int money;

    [Range(1, 99)]
    public int fieldview;
    public RAINBOW _rainbow;

    
   
}
