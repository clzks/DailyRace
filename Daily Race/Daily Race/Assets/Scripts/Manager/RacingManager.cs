using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RacehorseIndice
{
   public int horseIndex;
   public int riderIndex;
}

public class RacingManager : MonoBehaviour
{
    public List<RacehorseIndice> raceHorseList = new List<RacehorseIndice>();
    
    
    private void Awake()
    {
        MakeHorseRace(8);
        //raceHorseList.Clear();
    }

    private void Update()
    {
  
    }

    void MakeHorseRace(int horseNumber)       // 8마리의 말과 8명의 기수 랜덤으로 짝지은다
    {
        List<int> horseList = new List<int>();
        List<int> riderList = new List<int>();

        horseList = RandomizationList(horseNumber, SaveLoadManager.Instance.horseList.Count);
        riderList = RandomizationList(horseNumber, SaveLoadManager.Instance.riderList.Count);
        for (int i = 0; i < horseNumber; ++i)
        {
            RacehorseIndice rhIndice = new RacehorseIndice();
            rhIndice.horseIndex = horseList[i];
            rhIndice.riderIndex = riderList[i];
            raceHorseList.Add(rhIndice);
        }

    }

    int Randomization(int maxIndex)
    {
        int RandomNumber;
        RandomNumber = Random.Range(0, maxIndex);
        return RandomNumber;
    }

    List<int> RandomizationList(int count, int maxIndex)
    {
        List<int> wholeNumberList = new List<int>();
        List<int> RandomNumberList = new List<int>();
        for(int i = 0; i < maxIndex; ++i)
        {
            wholeNumberList.Add(i);
        }
        for (int i = 0; i < count; ++i)
        {
            int n = Random.Range(0, wholeNumberList.Count);
            RandomNumberList.Add(wholeNumberList[n]);
            wholeNumberList.Remove(wholeNumberList[n]);
        }
        
        return RandomNumberList;
    }                                                                
}
