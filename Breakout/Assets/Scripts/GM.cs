using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	
	public int lives = 5;
	public int bricks = 16;
	public float resetDelay = 1f;
    public int highScore;
    public int score = 1;
    public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;
	
	private GameObject clonePaddle;
	
	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		Setup();
		
	}
	
	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, new Vector3(-5.586268f, 6.611938f, 0.611002f), Quaternion.identity);
	}
	
	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			//Invoke ("Reset", resetDelay);
            Application.LoadLevel("Level2");
		}
		
		if (lives < 1)
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
	}
	
	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void LoseLife()
	{
		lives--;
		livesText.text = "LIVES : " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}
	
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}
	
	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}

    void Start()
    {
        highScore = PlayerPrefs.GetInt("High Score", highScore);

        if (score>=highScore)
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