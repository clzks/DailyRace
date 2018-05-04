using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class DayCalculator : MonoBehaviour  //  계산기이다. 이것은. 계산하기 위한. 날짜. 윤년은 걍 뺌
{
    public static DayCalculator instance = null;
    public static DayCalculator Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.R))
    //    {
    //        SceneManager.LoadScene("RaceTest");
    //    }
    //}

    public int CalculateYear(int wholeNumDay)
    {
        return ((wholeNumDay+1) / 360);
    }

    public int CalculateMonth(int wholeNumDay)
    {
        return ((wholeNumDay + 1) % 360 / 30) + 1 ;
    }

    public int CalculateDay(int wholeNumDay)
    {
        return (wholeNumDay + 1) % 30 + 1;
    }

    public string CalculateDayOfTheWeek(int wholeNumDay)
    {
        string s;
        switch (wholeNumDay % 7)
        {
            case 0:
                s = "(월)";
            break;
            case 1:
                s = "(화)";
            break;
            case 2:
                s = "(수)";
            break;
            case 3:
                s = "(목)";
            break;
            case 4:
                s = "(금)";
            break;
            case 5:
                s = "(토)";
            break;
            case 6:
                s = "(일)";
            break;
            default:
                s = "(요일)";
            break;
        }
        return s;
    }
}
