using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaceHorseData : MonoBehaviour
{
    public RaceHorseData raceHorseData;
    public int id;
    public int horseIndex;
    public int riderIndex;

    // 말 //
    public int horseID;
    public string horseName;           // 이름
    public int horseAge;               // 나이
  
    public int power;                  // 힘
    public int horseWeight;            // 중량
    public int sprint;                 // 주력
    public int accel;                  // 가속력
    public int indurance;              // 인내력
    public int durability;             // 내구성 
    public float maxBalance;           // 최대 밸런스 (게이지)
    public int suitSand;               // 모래 트랙 적합도 
    public int suitSoil;               // 흙 트랙 적합도 
    public int suitWater;              // 물 내성
    public int horseCondition;         // 0 ~ 5
    public int retire;

   
    // 기수 //

    public int riderID;
    public string riderName;
    public int riderAge;
  
    public int height;                  // 키
    public int riderWeight;             // 중량

    public int straight;                // 직선 주루
    public int curve;                   // 커브
    public int judgement;               // 판단력
    public int competitiveSprit;        // 승부욕  
    public int ethic;                   // 윤리의식
    public int professional;            // 프로의식 (스포츠맨십)

    public int riderCondition;

    // 경기에 필요한 핵심 변슈들

    public float angle;                // 현재 각도
    public float velocity;             // 현재 속력
    public float currBalance;          // 현재 밸런스 게이지
    public float stamina;              // 현재 체력 (100%)


    // 레이싱 변수 목록
    // 0. 최적 속도를 유지하기 힘들때
    // 1. 1등일 때
    // 2. 좌우에 상대가 보이는 상태일 때
    // * 앞쪽에 경로에 방해가 되는 상대가 있을 때
    // 3. 상대와의 거리가 안전거리 이상일때
    // 4. 상대와의 거리가 안전거리 이하일때
    // 5. 비스듬한 앞쪽에 상대가 존재할 때
    // 6. 마지막 레인일때
    // public int raceState;                 // 위쪽의 레이싱 변수를 int형으로 나타낼거임 그럴거임~ 안되는걸로 판단됨.

    // 말의 움직임을 제어할 변수들
    public bool isRaceStart;                 // 레이스가 시작했는가
    public bool isHorseStart;                // 말이 출발한 상태인가
    public bool isSpaceFinishLine;           // 결승선을 끊었는가
    public bool isMaitainOptimumSpeed;       // 최적속도를 유지하는 중인가
    public bool isFirstPlace;                // 1등인가
    public bool isFindOpponentLeft;          // 좌측에 상대방 발견
    public bool isFindOpponentRight;         // 우측에 상대방 발견
    public bool isFindOpponentForward;       // 전방에 상대가 있을때
    public bool isOpponentSafetyInside;      // 안전거리 안쪽         *안전거리란 자신의 말의 능력치를 토대로 계산한 게임상의 특정 거리~ 렬루다가
    public bool isOpponentSafetyOutside;     // 안전거리 바깥쪽
    public bool isOpponentDaiagonally;       // 적이 비스듬하게 있을뛔
    public bool isFinalLane;                 // 마지막 레인일때


    private void Start()
    {
        horseIndex = GetComponentInParent<RacingManager>().raceHorseList[id].horseIndex;
        riderIndex = GetComponentInParent<RacingManager>().raceHorseList[id].riderIndex;
        SetData(horseIndex, riderIndex);
    }


    public void SetData(int HorseIndex, int RiderIndex)
    {
        // 말 //
        horseID = SaveLoadManager.Instance.horseList[HorseIndex].id;
        horseName = SaveLoadManager.Instance.horseList[HorseIndex].horseName;          // 이름
        horseAge = SaveLoadManager.Instance.horseList[HorseIndex].age;               // 나이


        power = SaveLoadManager.Instance.horseList[HorseIndex].power;                  // 힘
        horseWeight = SaveLoadManager.Instance.horseList[HorseIndex].weight;            // 중량
        sprint = SaveLoadManager.Instance.horseList[HorseIndex].sprint;                 // 주력
        accel = SaveLoadManager.Instance.horseList[HorseIndex].accel;                  // 가속력
        indurance = SaveLoadManager.Instance.horseList[HorseIndex].indurance;              // 인내력
        durability = SaveLoadManager.Instance.horseList[HorseIndex].durability;             // 내구성 
        maxBalance = SaveLoadManager.Instance.horseList[HorseIndex].maxBalance;           // 최대 밸런스 (게이지)
        suitSand = SaveLoadManager.Instance.horseList[HorseIndex].suitSand;               // 모래 트랙 적합도 
        suitSoil = SaveLoadManager.Instance.horseList[HorseIndex].suitSoil;               // 흙 트랙 적합도 
        suitWater = SaveLoadManager.Instance.horseList[HorseIndex].suitWater;              // 물 내성
        horseCondition = SaveLoadManager.Instance.horseList[HorseIndex].condition;         // 0 ~ 5

        angle = 0.0f;
        velocity = SaveLoadManager.Instance.horseList[HorseIndex].velocity;             // 현재 속력
        currBalance = SaveLoadManager.Instance.horseList[HorseIndex].currBalance;          // 현재 밸런스 게이지
        stamina = SaveLoadManager.Instance.horseList[HorseIndex].stamina;              // 현재 체력 (100%)

        // 기수 //

        riderID = SaveLoadManager.Instance.riderList[RiderIndex].id;
        riderName = SaveLoadManager.Instance.riderList[RiderIndex].riderName;
        riderAge = SaveLoadManager.Instance.riderList[RiderIndex].age;

        height = SaveLoadManager.Instance.riderList[RiderIndex].height;                  // 키
        riderWeight = SaveLoadManager.Instance.riderList[RiderIndex].weight;             // 중량

        straight = SaveLoadManager.Instance.riderList[RiderIndex].straight;                // 직선 주루
        curve = SaveLoadManager.Instance.riderList[RiderIndex].curve;                   // 커브
        judgement = SaveLoadManager.Instance.riderList[RiderIndex].judgement;               // 판단력
        competitiveSprit = SaveLoadManager.Instance.riderList[RiderIndex].competitiveSprit;        // 승부욕  
        ethic = SaveLoadManager.Instance.riderList[RiderIndex].ethic;                   // 윤리의식
        professional = SaveLoadManager.Instance.riderList[RiderIndex].professional;            // 프로의식 (스포츠맨십)

        riderCondition = SaveLoadManager.Instance.riderList[RiderIndex].condition;

        isRaceStart = false;
        isHorseStart = false;
        isSpaceFinishLine = false;
        isMaitainOptimumSpeed = false;
        isFirstPlace = false;
        isFindOpponentLeft = false;
        isFindOpponentRight = false;
        isFindOpponentForward = false;
        isOpponentSafetyInside = false;
        isOpponentSafetyOutside = false;
        isOpponentDaiagonally = false;
        isFinalLane = false;
    }

    //public RaceHorseData(int HorseIndex, int RiderIndex)
    //{
    //   
    //
    //   
    //}
}
    