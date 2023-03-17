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

    //Just examples, need updating with real data
    public static string InsertFactorsIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (1, 'Factors', 1)";
    public static string InsertMultiplesIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (2, 'Multiples', 1)";
    public static string InsertLongDivisionIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (3, 'Long Division', 1)";

    //The data required in the topics table
    public static List<string> InsertIntoTopicsQueries = new List<string>
    {
        InsertFactorsIntoTopic,
        InsertMultiplesIntoTopic,
        InsertLongDivisionIntoTopic
    };

    public static string InsertQuestion1IntoFactors = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (1, 'What are the factors of 30?', '1, 2, 3, 5, 6, 10, 15, 30', 1)";
    public static string InsertQuestion2IntoFactors = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (2, 'What are the common factors of 12 and 18?', '1, 2, 3, 6', 1)";
    public static string InsertQuestion3IntoFactors = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (3, 'What is the prime factorization of 48?', '2 x 2 x 2 x 2 x 3', 1)";
    public static string InsertQuestion4IntoFactors = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (4, 'What is the greatest common factor of 16 and 24?', '8', 1)";

    public static List<string> InsertIntoFlashcardsQueries = new List<string>
    {
        InsertQuestion1IntoFactors,
        InsertQuestion2IntoFactors,
        InsertQuestion3IntoFactors,
        InsertQuestion4IntoFactors
    };


    public static string GetAllSubjects = "SELECT * FROM Subjects";
    public static string GetAllTopics = "SELECT * FROM Topics WHERE SubjectId = ";

}
