using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : MonoBehaviour
{
    public UserData userData;

    public UILabel year;
    public UILabel month;
    public UILabel day;
    public UILabel dayOfWeek;
    public UILabel money;

    private void Awake()
    {
        userData = SaveLoadManager.Instance.userData;
    }
    private void Update()
    {
        year.text = DayCalculator.Instance.CalculateYear(userData.wholeNumberOfDay).ToString();
        month.text = DayCalculator.Instance.CalculateMonth(userData.wholeNumberOfDay).ToString();
        day.text = DayCalculator.Instance.CalculateDay(userData.wholeNumberOfDay).ToString();
        dayOfWeek.text = DayCalculator.Instance.CalculateDayOfTheWeek(userData.wholeNumberOfDay);
        money.text = userData.money.ToString();

        Test();
    }

    private void LateUpdate()
    {
        
    }
    

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            userData.wholeNumberOfDay += 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            userData.wholeNumberOfDay += 5;

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            userData.wholeNumberOfDay += 30;
        }
    }
}
