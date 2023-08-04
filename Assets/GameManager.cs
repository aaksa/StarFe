using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject TapText;
    public GameObject TapToStart;


    public TextMeshProUGUI scoreText;

    //public SpriteRenderer spriteRenderer;
    public GameObject meteor;
    public Transform spawnPoint;



    int score;

    private int currentScore = 0;
    private int highestScore = 0;
    //private const string CurrentCharacterKey = "CurrentCharacter";

    bool gameStarted = false;


    public float MaxX;
    public float spawnRate;






    private void Awake()
    {
        TapText.SetActive(false);
        TapToStart.SetActive(true);

    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnPointObject = GameObject.Find("SpawnPoint");
        // Check if the GameObject is found

        if (spawnPointObject != null)
        {
            // Get the Transform component from the GameObject
            spawnPoint = spawnPointObject.transform;
        }
        else
        {
            Debug.LogError("Spawn Point GameObject not found!");
        }

        highestScore = LoadHighestScore();
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            //StartSpawning();
            TapToStart.SetActive(false);
            startSpawning();
            gameStarted = true;
            TapText.SetActive(false);
            Time.timeScale = 1f; // Pause the scene by setting timeScale to 0


        }
    }

    public void onPause()
    {
        gameStarted = false;
        TapText.SetActive(true);
        Time.timeScale = 0f; // Pause the scene by setting timeScale to 0
        CancelInvoke("spawnMeteor");

    }

    private void startSpawning()
    {
        InvokeRepeating("spawnMeteor", 0.5f, spawnRate);
    }

    private void spawnMeteor()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-MaxX, MaxX);

        Instantiate(meteor, spawnPos, Quaternion.identity);
        score++;
        UpdateScore(score);
        scoreText.text = "Score " +score.ToString();
    }

    public void UpdateScore(int points)
    {
        currentScore = points;
   

        SaveCurrentScore(currentScore);

        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            SaveHighestScore(highestScore);
        }
    }


    public void SaveCurrentScore(int currentScore)
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.Save();
    }

    public void SaveHighestScore(int highestScore)
    {
        PlayerPrefs.SetInt("HighestScore", highestScore);
        PlayerPrefs.Save();
    }

    public int LoadHighestScore()
    {
        return PlayerPrefs.GetInt("HighestScore", 0);
    }
}
