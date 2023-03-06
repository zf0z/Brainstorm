using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Queries
{
    

    public static string CreateSubjectsTableQuery = "DROP TABLE IF EXISTS Subjects; " +
                                                    "CREATE TABLE Subjects (" +
                                                    "Id INTEGER PRIMARY KEY, " +
                                                    "SubjectName VARCHAR(30))";

    public static string CreateTopicsTableQuery = "DROP TABLE IF EXISTS Topics; " +
                                                    "CREATE TABLE Topics (" +
                                                    "Id INTEGER PRIMARY KEY, " +
                                                    "TopicName VARCHAR(30), " +
                                                    "SubjectId INTEGER, " +
                                                    "FOREIGN KEY(SubjectId) " +
                                                    "REFERENCES Subjects(Id))";

    public static string CreateFlashcardsTableQuery = "DROP TABLE IF EXISTS Flashcards; " +
                                                    "CREATE TABLE Flashcards (" +
                                                    "Id INTEGER PRIMARY KEY, " +
                                                    "Question TEXT, " +
                                                    "Answer TEXT, " +
                                                    "TopicId INTEGER, " +
                                                    "FOREIGN KEY(TopicId) " +
                                                    "REFERENCES Topics(Id))";

    //The tables required in the database
    public static List<string> CreateTablesQueries = new List<string>
    {
        CreateSubjectsTableQuery,
        CreateTopicsTableQuery,
        CreateFlashcardsTableQuery
    };


    public static string InsertMathsIntoSubjects = "INSERT INTO Subjects(Id, SubjectName) VALUES (1, 'Maths')";
    public static string InsertEnglishIntoSubjects = "INSERT INTO Subjects(Id, SubjectName) VALUES (2, 'English')";
    public static string InsertPhysicsIntoSubjects = "INSERT INTO Subjects(Id, SubjectName) VALUES (3, 'Physics')";
    public static string InsertChemistryIntoSubjects = "INSERT INTO Subjects(Id, SubjectName) VALUES (4, 'Chemistry')";

    //The data required in the subjects table
    public static List<string> InsertIntoSubjectsQueries = new List<string>
    {
        InsertMathsIntoSubjects,
        InsertEnglishIntoSubjects,
        InsertPhysicsIntoSubjects,
        InsertChemistryIntoSubjects
    };

}
