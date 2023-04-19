using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager instance;
    private IDbConnection dbConnection;

    private void Start()
    {
        var filePath = Application.persistentDataPath + "/BrainstormDB.db";
        var connectionString = "URI=file:" + filePath;

        var newDatabase = !File.Exists(filePath);

        dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();

        //Dont need to initalize tables if they already exist.
        if (!newDatabase) return;

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

        //Inserts data into tables
        foreach (var query in Queries.InsertIntoTopicsQueries)
        {
            ExecuteQueryWithNoReturn(query);
        }

        foreach (var query in Queries.InsertIntoFlashcardsQueries)
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

    public void ExecuteQueryWithNoReturn(string query, string[] values)
    {
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = string.Format(query, values);
        dbCommand.ExecuteNonQuery();
    }

    public void ExecuteQueryWithNoReturn(string query)
    {
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        dbCommand.ExecuteNonQuery();
    }

    public List<T> ExecuteQueryWithReturn<T>(string query, string[] values) where T : new()
    {
        return GetData<T>(string.Format(query, values));
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
