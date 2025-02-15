using System;
using UnityEngine;

//요구 조건에 대한 스크립터블 오브젝트 생성
[Serializable]
[CreateAssetMenu(fileName = "Requirement", menuName = "Quest/requirement")]
public class Requirement : ScriptableObject
{
    public int 황금공수;
    public int 현재모은황금공수;
}

