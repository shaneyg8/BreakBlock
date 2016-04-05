using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Must be inputted to use UI options like Lives etc..


public class GMlvl2 : MonoBehaviour {

    public int lives = 4;
    public int blocks = 20;
    public float resetDelay = 1f;
    public int score = 2;
    public int highScore;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject blocksPrefab;
    public GameObject paddlelvl2;
    public GameObject deathParticles;
    public static GMlvl2 instance = null;

    private GameObject clonePaddle;

    // void Awake is used to start before void start()

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();

    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddlelvl2, transform.position, Quaternion.identity) as GameObject; //Where the position of the paddle should be
        Instantiate(blocksPrefab, new Vector3(-5.586268f, 6.611938f, 0.611002f), Quaternion.identity); //Positions the bricks to the centre
    }

    void CheckGameOver()
    {
        if (blocks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            //Invoke("Reset", resetDelay);
			Application.LoadLevel("Leaderboard");
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

    }

   /* void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }*/

    public void LoseLife()
    {
        lives--;
        livesText.text = "LIVES : " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddlelvl2, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBlock()
    {
        blocks--;
        CheckGameOver();
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("High Score", highScore);

        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);

        }
    }

    void OnGUI()
    {
        GUILayout.Label("High Score : " + highScore.ToString());
        GUILayout.Label("Current Score : " + score.ToString());
    }
}