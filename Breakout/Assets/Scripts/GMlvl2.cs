using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GMlvl2 : MonoBehaviour {

    public int lives = 4;
    public int blocks = 20;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject blocksPrefab;
    public GameObject paddlelvl2;
    public GameObject deathParticles;
    public static GMlvl2 instance = null;

    private GameObject clonePaddle;

    // Use this for initialization
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
        clonePaddle = Instantiate(paddlelvl2, transform.position, Quaternion.identity) as GameObject;
        Instantiate(blocksPrefab, new Vector3(-5.586268f, 6.611938f, 0.611002f), Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (blocks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
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
}