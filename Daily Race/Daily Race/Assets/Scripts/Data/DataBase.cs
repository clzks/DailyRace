using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.SqlClient;

public class DataBase : MonoBehaviour
{
    private UserData userData;
    private HorseData[] horseData;
    private RiderData[] riderData;

    private SqlConnection sqlConnection; 
    

    private void Awake()
    {
        SqlConnection dbConnection = new SqlConnection();
        dbConnection.Open();
        SqlCommand dbCommand = new SqlCommand();
        SqlDataReader dnReader = dbCommand.ExecuteReader();
    }

    private void LoadData()
    {

    }
}
