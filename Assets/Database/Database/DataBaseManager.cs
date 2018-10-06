/********************************************************         
 *       Scripted and Designed for MinionRunner         *   
 *                                                      *   
 *       Authors:  Christoph Drechsler                  *
 *                 Dean Dumitru                         *
 *                                                      *
 *       Contact: drechslerc@uindy.edu                  *
 *                dumitrud@uindy.edu                    *   
 *                                                      *   
 *                                                      *   
 *               All Rights Reserved.                   *   
 *                                                      *   
 ********************************************************/

using UnityEngine;
using System.Collections;
using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;

public class DataBaseManager : MonoBehaviour
{

    public static bool notInDB = false;
    public static bool notCorrect = false;
    public GameObject notInDBText;
    public GameObject notCorrectText;

    private static string connectionString =
            "Server=uindyrdb.cbr0wyxiy6tj.us-west-2.rds.amazonaws.com;" +
            "Database=uindyrdb;" +
            "UserID=uindyRDB;" +
            "Password=Usef1234;";
    //"Pooling=false";



    void Start()
    {

        CreateTable();

        /*
        IDbConnection dbcon;

        using (dbcon = new MySqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sql =
                    "SELECT name, email, password " +
                    "FROM Studentpi";
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string FirstName = (string)reader["name"];
                        string LastName = (string)reader["email"];
                        string UserName = (string)reader["password"];
                        Debug.Log(FirstName + LastName + UserName);
                    }
                }
            }
        }*/


    }

    private void CreateTable()
    {
        IDbConnection dbcon;
        using (dbcon = new MySqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                {
                    string sqlQuery = String.Format("CREATE TABLE IF NOT EXISTS StudentPI(id INT NOT NULL AUTO_INCREMENT,PRIMARY KEY(id),FirstName VARCHAR(16) NOT NULL,LastName VARCHAR(16) NOT NULL,email TEXT,password TEXT);");
                    dbcmd.CommandText = sqlQuery;
                    dbcmd.ExecuteScalar();
                    dbcon.Close();
                }
            }
            IDbConnection dbcon1;
            using (dbcon1 = new MySqlConnection(connectionString))
            {
                dbcon1.Open();
                using (IDbCommand dbcmd1 = dbcon1.CreateCommand())
                {
                    string sqlQuery = String.Format("CREATE TABLE IF NOT EXISTS StudentRecords(id INT NOT NULL AUTO_INCREMENT,PRIMARY KEY(id),FirstName VARCHAR(16) NOT NULL,LastName VARCHAR(16) NOT NULL, GivenFraction TEXT  NOT NULL, EnteredFraction TEXT  NOT NULL, EnteredReducedFraction TEXT  NOT NULL, EnteredDragFraction TEXT NOT NULL,Success INT DEFAULT NULL, TimeSpentProblem FLOAT DEFAULT NULL, TotalTime FLOAT DEFAULT NULL)");
                    dbcmd1.CommandText = sqlQuery;
                    dbcmd1.ExecuteScalar();
                    dbcon1.Close();
                }
            }

            /*
            using (dbcon = new MySqlConnection(connectionString))
            {
                dbcon.Open();
                using (IDbCommand dbcmd = dbcon.CreateCommand())
                {
                    {
                        string email = "dean";
                        string password = "dean";
                        string username = "dean";

                        string sqlQuery = String.Format("INSERT INTO Studentpi (name,email,password) VALUES(\"{0}\",\"{1}\",\"{2}\")",username, email, password);
                        dbcmd.CommandText = sqlQuery;
                        dbcmd.ExecuteScalar();
                        dbcon.Close();
                    }
                }
            }*/
        }
    }

    private static void InsertStudent(string email, string password, string firstName, string lastName, string level)
    {
        using (IDbConnection dbcon = new MySqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO StudentPI (FirstName,LastName,email,password) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", firstName, lastName, email, password);
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbcon.Close();
            }
        }

        SceneManager.LoadScene(level);
    }

    private static void GetStudent(string email, string password, string level)
    {
        string e = null;
        string p = null;
        string f = null;
        string u = null;
        string l = null;
        int ok = 0;

        using (IDbConnection dbcon = new MySqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sql =
                    "SELECT * " +
                    "FROM StudentPI";

                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        f = (string)reader["FirstName"];
                        l = (string)reader["LastName"];
                        e = (string)reader["email"];
                        p = (string)reader["password"];
                       
                        u = f + " " + l;


                        if (e == email && p == password)
                        {
                            ok = 1;
                            break;
                        }
                    }

                    if (ok == 1)
                    {
                        UserClass.player.email = e;
                        UserClass.player.firstName = f;
                        UserClass.player.lastName = l;
                        UserClass.player.userId = u;
                        allowLogin(email, level);
                    }
                    else if ((e == email && p != password) || (e != email && p == password))
                        denyLogin();
                    else requireRegister();
                    dbcon.Close();
                    reader.Close();
                }
            }
        }
    }

    static void allowLogin(string email, string level)
    {
        /////// ERROR: Database is Locked 
        /*using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO StudentLoginRegister (Email) VALUES(\"{0}\")", email);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }*/
        /////////////////////////////

        SceneManager.LoadScene(level);
    }

    static void denyLogin()
    {
        notCorrect = true;
    }
    static void requireRegister()
    {
        notInDB = true;
    }

    private static void InsertStudentRecord(string givenFraction, string enteredFraction, string enteredRFraction, string enteredDragFraction, int success, float time, float totalTime)
    {
        string fn = UserClass.player.firstName;
        string ln = UserClass.player.lastName;

        using (IDbConnection dbcon = new MySqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO StudentRecords (FirstName,LastName,GivenFraction,EnteredFraction,EnteredReducedFraction,EnteredDragFraction,Success, TimeSpentProblem, TotalTime) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\")", fn, ln, givenFraction, enteredFraction, enteredRFraction, enteredDragFraction, success, time, totalTime);
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbcon.Close();
            }
        }
    }

    public static void registerStudent(string email, string password, string firstName, string lastName, string level)
    {
        InsertStudent(email, password, firstName, lastName, level);
    }

    public static void loginStudent(string email, string password, string level)
    {
        GetStudent(email, password, level);
    }

    public static void writeSuccess(string givenFraction, string enteredFraction, string enteredRFraction, string enteredDragFraction, int success, float time, float totalTime)
    {
        InsertStudentRecord(givenFraction, enteredFraction, enteredRFraction, enteredDragFraction, success, time, totalTime);
    }
}