using System;
using UnityEngine;


[Flags]
public enum RAINBOW
{
    None = 0,
    �� = 1 << 0, 
    �� = 1 << 1, 
    �� = 1 << 2, 
    �� = 1 << 3, 
    �� = 1 << 4, 
    �� = 1 << 5, 
    �� = 1 << 6
}

[AddComponentMenu("JBY/Sample01")]
public class Sample01 : MonoBehaviour
{
    [Tooltip("üũ�Ǹ� ��������")]
    public bool jumpable;

    public string[] fruits;

    public int money;

    [Range(1, 99)]
    public int fieldview;
    public RAINBOW _rainbow;

    
   
}
