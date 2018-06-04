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

    public float velocity;             // 현재 속력
    public float currBalance;          // 현재 밸런스 게이지
    public float stamina;              // 현재 체력 (100%)


    public void Setting()
    {
        horseIndex = GetComponentInParent<RacingManager>().raceHorseList[id].horseIndex;
        riderIndex = GetComponentInParent<RacingManager>().raceHorseList[id].riderIndex;
        SetData(horseIndex, riderIndex);
    }


    private void Start()
    {
        //horseIndex = GetComponentInParent<RacingManager>().raceHorseList[id].horseIndex;
        //riderIndex = GetComponentInParent<RacingManager>().raceHorseList[id].riderIndex;
        //SetData(horseIndex, riderIndex);
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

    
    }

    //public RaceHorseData(int HorseIndex, int RiderIndex)
    //{
    //   
    //
    //   
    //}
}
    