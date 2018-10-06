using Mono.Data.Sqlite;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

/// <summary>
/// This script handles all communication with the database
/// </summary>
public class HighScoreManager : MonoBehaviour
{

    private string connectionString =
            "Server=uindyrdb.cbr0wyxiy6tj.us-west-2.rds.amazonaws.com;" +
            "Database=uindyrdb;" +
            "UserID=uindyRDB;" +
            "Password=Usef1234;";
    //"Pooling=false";

    private List<HighScore> highScores = new List<HighScore>();

    public GameObject scorePrefab;

    public Transform scoreParent;

    public int topRanks;

    public int saveScores;

    public InputField enterName;

    public GameObject nameDialog;

    public GameObject GameOverText;
    public GameObject UsernameOTOTS;

    // Use this for initialization
    void Start()
    {
        //Creates the database if it doesn't exist
        CreateTable();

        //Deletes the extra scores
        DeleteExtraScore();

        //Shows the scores to the player
        ShowScores();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDestroy.playerDead == true)
        {
            GameOverText.SetActive(true);
            UsernameOTOTS.SetActive(false);
            EnterName();
            PlayerDestroy.playerDead = false;
        }
    }

    /// <summary>
    /// Creates a table if it doesn't exist
    /// </summary>
    /// 


    private void CreateTable()
    {
        IDbConnection dbcon;
        using (dbcon = new MySqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                //Create the query 
                {
                    string sqlQuery = String.Format("CREATE TABLE IF NOT EXISTS HighScores(id INT NOT NULL AUTO_INCREMENT,PRIMARY KEY(id),FirstName VARCHAR(16) NOT NULL,LastName VARCHAR(16) NOT NULL, Score INT NOT NULL , Date DATETIME DEFAULT   CURRENT_TIMESTAMP)");
                    dbcmd.CommandText = sqlQuery;
                    dbcmd.ExecuteScalar();
                    dbcon.Close();
                }
            }
        }
    }

    /// <summary>
    /// Is called when the player is pressing the OK Button
    /// </summary>
    public void EnterName()
    {

        int score = Scoring.score;

        InsertScore(UserClass.player.firstName, UserClass.player.lastName, score); //Inserts the score in the database

        enterName.text = string.Empty; //resets the textfield

        ShowScores(); //Gets the scores form the database

    }

    /// <summary>
    /// Inserts  the score into the database
    /// </summary>
    /// <param name="name">The name of the player</param>
    /// <param name="newScore">The player's score</param>
    private void InsertScore(string firstName, string lastName, int newScore)
    {
        GetScores(); //Gets the scores from the database

        int hsCount = highScores.Count; //Stores the amount of scores

        if (highScores.Count > 0) //If we have more than 0 highscores
        {
            HighScore lowestScore = highScores[highScores.Count - 1]; //Creates a reference to the lowest score

            //If the lowest score needs to be replaced
            if (lowestScore != null && saveScores > 0 && highScores.Count >= saveScores && newScore > lowestScore.Score)
            {
                DeleteScore(lowestScore.ID); //Deletes the lowest score

                hsCount--; //Reduces the amount of scores, so that we know if we should insert a new score
            }
        }
        if (hsCount < saveScores) //If there is room on the highscore list, then insert a new score
        {
            //Creates a database connection
            IDbConnection dbcon;
            using (dbcon = new MySqlConnection(connectionString))
            {
                dbcon.Open();
                using (IDbCommand dbcmd = dbcon.CreateCommand())
                {
                    //Creates a query for inserting the new score
                    string sqlQuery = String.Format("INSERT INTO HighScores(FirstName, LastName, Score) VALUES(\"{0}\",\"{1}\",\"{2}\")", firstName, lastName, newScore);
                    dbcmd.CommandText = sqlQuery;
                    dbcmd.ExecuteScalar();
                    dbcon.Close();
                }
            }
        }
    }

    /// <summary>
    /// Gets the scores from the database
    /// </summary>
    private void GetScores()
    {
        //Clears the highscore list so that we can get the new scores
        highScores.Clear();

        //Creates a database connection
        IDbConnection dbcon;
        using (dbcon = new MySqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                //Selects everything from the highscores
                string sqlQuery = "SELECT * FROM HighScores";

                //feeds the query to the command
                dbcmd.CommandText = sqlQuery;

                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string FirstName = (string)reader["FirstName"];
                        string LastName = (string)reader["LastName"];
                        int id = (int)reader["id"];
                        int score = (int)reader["Score"];
                        DateTime date = (DateTime)reader["Date"];

                        highScores.Add(new HighScore(id, score, FirstName, LastName, date));
                        //Creates a reader and executes it so that we can load the highscores
                    }

                        //Closes the connection
                        dbcon.Close();
                        reader.Close();
                    
                }
            }
        }

        highScores.Sort(); //Sorts the highscore from highest to lowest
    }

    private void DeleteScore(int id)
    {
        IDbConnection dbcon;
        using (dbcon = new MySqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                //Creates a query
                string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", id);

                //Feeds the query to the command
                dbcmd.CommandText = sqlQuery;

                //Executes the command
                dbcmd.ExecuteScalar();

                //Closes the connection
                dbcon.Close();
            }
        }
    }



    /// <summary>
    /// Shows the scores to the player
    /// </summary>
    private void ShowScores()
    {
        GetScores(); //Gets the scores from the database

        //Runs through all the scores
        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            //Destroyes all the old scores
            Destroy(score);
        }

        for (int i = 0; i < topRanks; i++) //This loops makes sure that we only show the top x sores
        {
            if (i <= highScores.Count - 1) //Makes sure that we don't get an index out of bounds exception
            {
                GameObject tmpObjec = Instantiate(scorePrefab); //Instantiates a new score

                HighScore tmpScore = highScores[i]; //Gets the current highscore

                //Sets the objects score
                tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.FirstName, tmpScore.LastName, tmpScore.Score.ToString(), "#" + (i + 1).ToString());

                tmpObjec.transform.SetParent(scoreParent); //Sets the score of the parent

                tmpObjec.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //Makes sure that the object has the correct scale
            }

        }
    }

    /// <summary>
    /// Deletes the extra scores, this is based on the saveScores variable
    /// </summary>
    private void DeleteExtraScore()
    {
        GetScores(); //Gets the current scores

        if (saveScores <= highScores.Count) //if the amount of scores to save is less than the amount of saves scores
        {
            int deleteCount = highScores.Count - saveScores; //Store the number of scores to delete

            highScores.Reverse(); //Reverses the order so that it is easier for us to delete the lowest scores

            using (IDbConnection dbcon = new MySqlConnection(connectionString))
            {
                dbcon.Open();
                using (IDbCommand dbcmd = dbcon.CreateCommand())
                {
                    for (int i = 0; i < deleteCount; i++) //Deletes the scores
                    {
                        //Creates the sqlQuery for deleting the highscore
                        string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", highScores[i].ID);

                        //Feeds the query to the commandText
                        dbcmd.CommandText = sqlQuery;

                        dbcmd.ExecuteScalar(); //Executes the command
                    }

                    dbcon.Close(); //Closes the connection


                }
            }
        }
    }
}
