using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    private void Start()
    {
        Application.LoadLevelAdditive("UI_Main");
    }

    private void Update()
    {
        
    }

    public void ChangeRaceTest()
    {
        SceneManager.LoadScene("RaceTest");
    }
}
