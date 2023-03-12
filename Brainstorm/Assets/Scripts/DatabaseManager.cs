using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager instance;

    private string connectionString;
    private IDbConnection dbConnection;


    private void Start()
    {
        connectionString = "URI=file:" + Application.persistentDataPath + "/BrainstormDB";
        dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();

        //add if database not exists later

        //Creates the tables in the database
        foreach (var query in Queries.CreateTablesQueries)
        {
            ExecuteQueryWithNoReturn(query);
        }

        //Inserts data into tables
        foreach (var query in Queries.InsertIntoSubjectsQueries)
        {
            ExecuteQueryWithNoReturn(query);
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if(dbConnection != null && dbConnection.State != ConnectionState.Closed)
        {
            dbConnection.Close();
            dbConnection = null;
        }
    }

    public void ExecuteQueryWithNoReturn(string query)
    {
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        dbCommand.ExecuteNonQuery();
    }

    public List<T> ExecuteQueryWithReturn<T>(string query) where T : new()
    {
        return GetData<T>(query);
    }
    
    private List<T> GetData<T>(string query) where T : new()
    {
        List<T> result = new List<T>();

        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;

        var reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            var row = new T();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string name = reader.GetName(i);
                PropertyInfo property = typeof(T).GetProperty(name);

                if (property != null && reader.GetValue(i) != DBNull.Value)
                {
                    property.SetValue(row, reader.GetValue(i));
                }
            }

            result.Add(row);
        }

        return result;
    }
}
