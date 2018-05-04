using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{

    public int wholeNumberOfDay;         // 총 일수
    //public int year;                                                    
    //public int month;                                                   
    //public int day;                                                     
                                                                          
    //public int dayOfTheWeek;        // 요일 (0~6) (월~일)                  

    public int fame;
    public int money;
    public int actPower;            // 행동력
    
    public UserData(int WholeNumberofDay , int Fame, int Money, int AP)
    {
        wholeNumberOfDay = WholeNumberofDay;
        fame = Fame;
        money = Money;
        actPower = AP;
    }
}
