using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount = 10;
    public float spawnWait = 1;
    public float startWait = 1;
    public float waveWait = 4;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text exitText;
    private bool restart;
    private int score;
    public int health = 50;
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    void Start()
    {
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        exitText.text = "";
        score = 0;
        UpdateScore();
        UpdateHealth();
        StartCoroutine(SpawnWaves());
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
          Application.Quit();
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(
                   Random.Range(-spawnValues.x, spawnValues.x),
                   Random.Range(1, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void MinusHealth(int newHealthValue)
    {


        if (GameController.instance.health > 0)
        {
          health -= newHealthValue;
        }
        else if (GameController.instance.health <= 0)
        {
            GameController.instance.GameOver();

        }

        UpdateHealth();
    }
    void UpdateScore()
    {
        scoreText.text = "LPC";
    }
    void UpdateHealth()
    {
        restartText.text = "Health : " + health;

    }

    public void GameOver()
    {

        gameOverText.text = "Game Over!";
        exitText.text = "[ESC] for Exit!";
        restartText.text = "Press [R] for Restart";
        restart = true;

    }
}
