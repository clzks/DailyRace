using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseData
{
    public int id;
    public string horseName;           // 이름
    public int age;                    // 나이
    public int potential;              // 포텐
    
    public int fame;                    // 명성
    public int power;                   // 힘
    public int weight;                  // 중량
    public int sprint;                  // 주력
    public int accel;                   // 가속력
    public int indurance;               // 인내력
    public int durability;              // 내구성 
    public float maxBalance;              // 최대 밸런스 (게이지)
    public int suitSand;                // 모래 트랙 적합도 
    public int suitSoil;                // 흙 트랙 적합도 
    public int suitWater;               // 물 내성
    public int condition;               // 0 ~ 5
    public int retire;
    public int first;                   // 1위
    public int second;                  // 2위
    public int third;                   // 3위


    public float velocity;             // 현재 속력
    public float currBalance;          // 현재 밸런스 게이지
    public float stamina;              // 현재 체력 (100%)

    // public color horseColor
    
    public HorseData(int ID, string HorseName, int Age, int Potential, int Fame, int Power, int Weight, int Sprint, int Accel, int Indurance, int Durability, 
                     float MaxBalance, int SuitSand, int SuitSoil, int SuitWater, int Condition, int Retire, int First, int Second, int Third,
                     float Velocity, float CurrBalance, float Stamina) // 생성자
    {
        id = ID;
        horseName = HorseName;
        age = Age;
        potential = Potential;
        fame = Fame;
        power = Power;
        weight = Weight;
        sprint = Sprint;
        accel = Accel;
        indurance = Indurance;
        durability = Durability;
        maxBalance = MaxBalance;
        suitSand = SuitSand;
        suitSoil = SuitSoil;
        suitWater = SuitWater;
        condition = Condition;
        retire = Retire;
        first = First;
        second = Second;
        third = Third;
        velocity = Velocity;
        currBalance = CurrBalance;
        stamina = Stamina;
    }
}
