using System;
using UnityEngine;


public class Monster : Character
{
   
    public float monster_speed;
    public float rate = 0.5f;

    protected override void Start()
    {
        base.Start();
    }

    //Action 테스트
    public void MonsterSample()
    {
        Debug.Log("몬스터가 생성되었습니다.");
    }

    // Update is called once per frame
    void Update()
    {
        // 영점 기준으로 시선 변경(현재 플레이어가 영점에 있기때문에. 응용하면 플레이어의 위치로 설정하면 된다)
        transform.LookAt(Vector3.zero);
        

        // 간격 설정
        float target_distance = Vector3.Distance(transform.position, Vector3.zero);

        if(target_distance <= rate) // 간격 거리와 가까워지면 이동 중지
        {
            SetMotionChange("isMOVE", false);
        }
        else // 일반적인 경우에는 움직임을 진행한다.
        {
            // 영점으로 몬스터의 속도만큼 앞으로 이동
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * monster_speed);
            
            SetMotionChange("isMOVE", true);
        }



       
    }

   
}
