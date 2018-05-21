using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Control_AI : MonoBehaviour
{
    public RaceHorseData rhData;

    public float CurrVelocity;
    public float turnSpeed;

    public float fRayDistance;
    private Vector3 fHorseAngle;  // 말의 방향각도
    private Transform rayPositionTrack; // 벽과의 레이 시작 위치

    private Ray rayLeftTrack;   // 왼쪽 벽 레이
    private Ray rayRightTrack;  // 오른쪽 벽 레이

    private float fLeftDistance;    // 왼쪽 벽과의 거리
    private float fRightDistance;   // 오른쪽 벽과의 거리


    private void Awake()
    {
        rhData = GetComponentInParent<RaceHorseData>();
       
    }

    private void FixedUpdate()  
    {
        rayPositionTrack = GetComponentInChildren<Transform>();
        fHorseAngle = rayPositionTrack.rotation.eulerAngles;

        rayLeftTrack.origin = rayPositionTrack.position + new Vector3(0, 0.2f ,0);
        rayLeftTrack.direction = fHorseAngle + new Vector3(0, 0, -90.0f);

        rayRightTrack.origin = rayPositionTrack.position + new Vector3(0, 0.2f, 0);
        rayRightTrack.direction = fHorseAngle + new Vector3(0, 0, 90.0f);
        
        RaycastHit rayHit;
        // 왼쪽 레이 검사
        if (Physics.Raycast(rayLeftTrack, out rayHit, fRayDistance))
            fLeftDistance = rayHit.distance;
        // 오른쪽 레이 검사
        if (Physics.Raycast(rayRightTrack, out rayHit, fRayDistance))
            fRightDistance = rayHit.distance;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // 충돌 검사에 의해서 줄어든 레이를 그린다.
        Gizmos.DrawLine(rayLeftTrack.origin,
            rayLeftTrack.origin + rayLeftTrack.direction * fRayDistance);

        Gizmos.color = Color.blue;

        Gizmos.DrawLine(rayRightTrack.origin,
            rayRightTrack.origin + rayRightTrack.direction * fRayDistance);
    }

    void RaceHorse()
    {


    }
}
