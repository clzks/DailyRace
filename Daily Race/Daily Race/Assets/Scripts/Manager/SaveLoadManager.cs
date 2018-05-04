using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.SqliteClient;
using System.IO;
using System.Data;

public class SaveLoadManager : MonoBehaviour
{
    public List<HorseData> horseList;
    public List<RiderData> riderList;
    public UserData userData;

    public static SaveLoadManager instance = null;
    public static SaveLoadManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }


    void Start()
    { 
        StartCoroutine(Main());
    }

    IEnumerator Main()
    {
        yield return StartCoroutine(UserDbParsing("WR_DB.sqlite"));    // 유저 정보 파싱. 
        //yield return StartCoroutine(HorseDbParsing("WR_DB.sqlite"));   // 말 정보 파싱. 
        //yield return StartCoroutine(RiderDbParsing("WR_DB.sqlite"));   // 기수 정보 파싱. 정보가 필요할 때 파싱, 정보가 변화할 때 저장!
    }

    // 코루틴 .
    IEnumerator UserDbParsing(string p)
    {

        string Filepath = Application.persistentDataPath + "/" + p;

        if (!File.Exists(Filepath))
        {
            Debug.LogWarning("File \"" + Filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/" + p);

            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
            while (!loadDB.isDone) { }
            File.WriteAllBytes(Filepath, loadDB.bytes);
        }

        string connectionString = "URI=file:" + Filepath;

        // using을 사용함으로써 비정상적인 예외가 발생할 경우에도 반드시 파일을 닫히도록 할 수 있다.
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())  // EnterSqL에 명령 할 수 있다. 
            {

                string sqlQuery = "SELECT * FROM InitUserInfo";


                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader()) // 테이블에 있는 데이터들이 들어간다. 
                {
                    while (reader.Read())
                    {
                        // Debug.Log(reader.GetString(1));  //  타입명 . (몇 열에있는것을 불를것인가)
                        userData = new UserData(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        print(userData.wholeNumberOfDay);
        print(userData.money);
        print(userData.fame);
        print(userData.actPower);


        yield return null;
    }

    IEnumerator HorseDbParsing(string p)
    {

        string Filepath = Application.persistentDataPath + "/" + p;

        if (!File.Exists(Filepath))
        {
            Debug.LogWarning("File \"" + Filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/" + p);

            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
            while (!loadDB.isDone) { }
            File.WriteAllBytes(Filepath, loadDB.bytes);
        }

        string connectionString = "URI=file:" + Filepath;


        horseList.Clear();

        // using을 사용함으로써 비정상적인 예외가 발생할 경우에도 반드시 파일을 닫히도록 할 수 있다.
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())  // EnterSqL에 명령 할 수 있다. 
            {

                string sqlQuery = "SELECT * FROM InitHorseInfo";


                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader()) // 테이블에 있는 데이터들이 들어간다. 
                {
                    while (reader.Read())
                    {
                        // Debug.Log(reader.GetString(1));  //  타입명 . (몇 열에있는것을 불를것인가)

                       // horseList.Add(new Item(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));


                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

        for (int i = 0; i < horseList.Count; i++)
        {
          //  Debug.Log(horseList[i].ID + "::" + horseList[i].Name + "::" + horseList[i].Des);


        }

        yield return null;
    }

    IEnumerator RiderDbParsing(string p)
    {

        string Filepath = Application.persistentDataPath + "/" + p;

        if (!File.Exists(Filepath))
        {
            Debug.LogWarning("File \"" + Filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/" + p);

            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
            while (!loadDB.isDone) { }
            File.WriteAllBytes(Filepath, loadDB.bytes);
        }

        string connectionString = "URI=file:" + Filepath;


        horseList.Clear();

        // using을 사용함으로써 비정상적인 예외가 발생할 경우에도 반드시 파일을 닫히도록 할 수 있다.
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())  // EnterSqL에 명령 할 수 있다. 
            {

                string sqlQuery = "SELECT * FROM InitRiderInfo";


                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader()) // 테이블에 있는 데이터들이 들어간다. 
                {
                    while (reader.Read())
                    {
                        // Debug.Log(reader.GetString(1));  //  타입명 . (몇 열에있는것을 불를것인가)

                       // riderList.Add(new Item(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));


                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

        for (int i = 0; i < horseList.Count; i++)
        {
           // Debug.Log(riderList[i].ID + "::" + riderList[i].Name + "::" + riderList[i].Des);


        }

        yield return null;
    }
}
