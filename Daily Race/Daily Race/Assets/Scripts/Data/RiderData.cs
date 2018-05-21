using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderData
{
    public int id;
    public string riderName;
    public int age;
    public int potential;

    public int fame;
    public int height;                  // 키
    public int weight;                  // 중량

    public int straight;                // 직선 주루
    public int curve;                   // 커브
    public int judgement;               // 판단력
    public int competitiveSprit;        // 승부욕  
    public int ethic;                   // 윤리의식
    public int professional;            // 프로의식 (스포츠맨십)

    public int condition;
    

    public RiderData(int ID, string RiderName, int Age, int Potential, int Fame, int Height, int Weight, int Straight, int Curve, 
                     int Judgement, int CompetitiveSprit, int Ethic, int Professional, int Condition)
    {
        id = ID;
        riderName = RiderName;
        age = Age;
        potential = Potential;
        fame = Fame;
        height = Height;
        weight = Weight;
        straight = Straight;
        curve = Curve;
        judgement = Judgement;
        competitiveSprit = CompetitiveSprit;
        ethic = Ethic;
        professional = Professional;
        condition = Condition;
    }
}
