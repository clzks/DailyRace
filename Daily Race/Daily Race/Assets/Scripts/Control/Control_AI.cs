using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Control_AI : MonoBehaviour
{
    public RaceHorseData rhData;


    public float fCurrMaxVelocity;     // 현재 강도의 최대속력
    public float fCurrVelocity;        // 현재 속력

    public float fTurnSpeed;

    public float fRayDistance;
    public Vector3 fCurrAngle;        // 말의 방향각도
    private Transform trCurrPos;       // 현재 포지션
    private Transform rayPositionTrack; // 벽과의 레이 시작 위치

    private Ray rayLeftFront;   // 왼쪽 앞 레이
    private Ray rayLeftMiddle;  // 왼쪽 중간 레이
    private Ray rayLeftRear;    // 왼쪽 뒤 레이

    private Ray rayRightFront;  // 오른쪽 앞 레이
    private Ray rayRightMiddle; // 오른쪽 중간 레이
    private Ray rayRightRear;   // 오른쪽 뒤 레이

    private Ray rayHorseLeftForward;      // 전방의 왼쪽 레이
    private Ray rayHorseMiddleForward;    // 전방의 앞쪽 레이
    private Ray rayHorseRightForward;     // 전방의 오른쪽 레이

    public Vector3 rayRouteFront = new Vector3();       // 각을 잴 레이힛
    public Vector3 rayRouteRear = new Vector3();       // 각을 잴 레이힛

    private RaycastHit rayHitLeftFirst;
    private RaycastHit rayHitLeftSecond;
    private RaycastHit rayHitRightFirst;
    private RaycastHit rayHitRightSecond;


    public int nCurrentRank;             // 현재 순위
    public float fOptimumstrength;       // 최적 강도
    public float fCurrStrength;          // 현재 달리기 강도
    public float fSafetyDistance;        // 안전거리

    

    private float fLeftDistance;        // 왼쪽 벽과의 거리
    private float fLeftDistance1;        // 왼쪽 벽과의 거리

    private float fRightDistance;       // 오른쪽 벽과의 거리
    private float fRightDistance1;       // 오른쪽 벽과의 거리


    private int nBifuricationIndex;     // 분기
    private int nRouteIndex;            // 경로 인덱스
    private int nSpeedIndex;            // 속도 인덱스
   
    private bool isRaceStart = false;                    // 레이스가 시작했는가
    
    private bool isFinalLane = false;                    // 마지막 레인일때


    private void Awake()
    {
     
    }

    private void Start()
    {
        rhData = GetComponent<RaceHorseData>();
        rhData.Setting();
        trCurrPos = GetComponentInChildren<Transform>();
        rayPositionTrack = GetComponentInChildren<Transform>();
        // 최적속도 결정 해야함
        SetOptimumSpeed();
        // 안전속도 결정 해야함
        Debug.Log(rhData.id + "번말 최적강도 :" + fOptimumstrength);
        fCurrAngle = rayPositionTrack.forward;
    }

    private void FixedUpdate()  
    {
        // 일단 두개는 같음
        SetSafetyDistance(); // 안전거리 세팅


        rayLeftFront.origin = rayPositionTrack.position + new Vector3(-0.10f, 0.2f, 0);
        rayLeftFront.direction = rayPositionTrack.right * -1.0f;
        rayLeftMiddle.origin = rayPositionTrack.position + new Vector3(-0.05f, 0.2f, 0);
        rayLeftMiddle.direction = rayPositionTrack.right * -1.0f;
        rayLeftRear.origin = rayPositionTrack.position + new Vector3(0.00f, 0.2f ,0);
        rayLeftRear.direction = rayPositionTrack.right * -1.0f;

        rayRightFront.origin = rayPositionTrack.position + new Vector3(-0.10f, 0.2f, 0);
        rayRightFront.direction = rayPositionTrack.right;
        rayRightMiddle.origin = rayPositionTrack.position + new Vector3(-0.05f, 0.2f, 0);
        rayRightMiddle.direction = rayPositionTrack.right;
        rayRightRear.origin = rayPositionTrack.position + new Vector3(0.00f, 0.2f, 0);
        rayRightRear.direction = rayPositionTrack.right;

        rayHorseLeftForward.origin = rayPositionTrack.position + new Vector3(0, 0.2f, 0);
        rayHorseLeftForward.direction = rayPositionTrack.forward;
          

        
        // 왼쪽 레이 검사
        //if (Physics.Raycast(rayLeftRear, out rayHitLeftSecond, fRayDistance, 1<<8))
        //    fLeftDistance1 = rayHitLeftSecond.distance;
        if (Physics.Raycast(rayLeftFront, out rayHitLeftFirst, fRayDistance, 1<<8))
            fLeftDistance = rayHitLeftFirst.distance;

        // 오른쪽 레이 검사
        //if (Physics.Raycast(rayRightRear, out rayHitRightSecond, fRayDistance, 1 << 9))
        //    fRightDistance1 = rayHitRightSecond.distance;
        if (Physics.Raycast(rayRightFront, out rayHitRightFirst, fRayDistance, 1 << 9))
            fRightDistance = rayHitRightFirst.distance;

        if (fLeftDistance <= fRightDistance)
        { 
            rayRouteFront = rayLeftFront.origin + fLeftDistance * rayPositionTrack.right * -1.0f;
            //rayRouteRear = rayLeftRear.origin + fLeftDistance1 * rayPositionTrack.right * -1.0f;
        }
        else
        {
            rayRouteFront = rayRightFront.origin + fRightDistance * rayPositionTrack.right;
            //rayRouteRear = rayRightRear.origin + fRightDistance1 * rayPositionTrack.right;
        }

        

        

        RaceHorse();

        //Time.fixedDeltaTime * 0.1f;
        rayRouteRear = rayRouteFront;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // 충돌 검사에 의해서 줄어든 레이를 그린다.
        Gizmos.DrawLine(rayLeftFront.origin,
           rayLeftFront.origin + rayLeftFront.direction * fLeftDistance);
        Gizmos.DrawLine(rayLeftMiddle.origin,
           rayLeftMiddle.origin + rayLeftMiddle.direction * fLeftDistance);
        Gizmos.DrawLine(rayLeftRear.origin,
            rayLeftRear.origin + rayLeftRear.direction * fLeftDistance);
        
        Gizmos.color = Color.blue;
        
        Gizmos.DrawLine(rayRightFront.origin,
            rayRightFront.origin + rayRightFront.direction * fRightDistance);
        Gizmos.DrawLine(rayRightMiddle.origin,
           rayRightMiddle.origin + rayRightMiddle.direction * fRightDistance);
        Gizmos.DrawLine(rayRightRear.origin,
           rayRightRear.origin + rayRightRear.direction * fRightDistance);
        Gizmos.color = Color.gray;
        
        Gizmos.DrawLine(rayHorseLeftForward.origin,
            rayHorseLeftForward.origin + rayHorseLeftForward.direction * 1.0f);
    }

    void RaceHorse()
    {
        if(!isRaceStart) // 경기 시작했는가
        {
            if(Input.GetKey(KeyCode.S))
            {
                isRaceStart = true;
            }
        }

       
        
        if (isRaceStart)     // 일단 경기 시작
        {
            SetNormalRoute();

            SetMaxVelocity();  // 속도 세팅

            RunHorse();
        }
    }
    public void CheckPace()
    {
    
    }

    public void RunHorse()      // 말이 달린다.
    {
        fCurrVelocity = fOptimumstrength * (1.0f + rhData.sprint * 0.005f) * rhData.stamina * 0.01f * rhData.horseCondition * 0.01f * 0.002f;
        rayPositionTrack.position += fCurrVelocity * fCurrAngle;
    }
    // // 레이스가 시작했는가

    public void SetNormalRoute()
    {
        if (rayRouteFront != rayRouteRear)
        {
            Vector3 Dir = Vector3.Normalize(rayRouteFront - rayRouteRear);
            if (Dir.magnitude != 0)
            {
                fCurrAngle = Dir;

                // **************** 중요 ******************
                Vector3 look = rayPositionTrack.position + Dir;
                rayPositionTrack.LookAt(look);
            }
        }
    }

    public void SetMaxVelocity()
    {
        // 강도 * 주력(1과 20은 1.095배)
        fCurrMaxVelocity = fCurrStrength * (1.0f + rhData.sprint * 0.005f) * rhData.stamina * 0.01f * rhData.horseCondition * 0.01f;
    }

    // 안전거리 세팅
    public void SetSafetyDistance()          
    {
        fSafetyDistance = fCurrVelocity * Time.fixedDeltaTime * 5.0f + 0.25f;       // 안전거리는 현재 속도의 5배 이다 , 0.25f는 말과 말이 딱 붙어있는 것보다 살짝 큰 거리.
    }

    public void SetOptimumSpeed()
    {
        fOptimumstrength = (float)rhData.indurance * 0.05f + 4.0f + (float)rhData.power * 0.05f + 2.0f;
    }
    
}
