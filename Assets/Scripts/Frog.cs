using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {

    public bool gameIsPaused = false;
    public GameObject pauseTextObject;
    public Rigidbody2D rb;
    public static int LIVES = 3;
    static string writeScore;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update () {

		if (Input.GetKeyDown(KeyCode.D))
			rb.MovePosition(rb.position + Vector2.right);
		else if (Input.GetKeyDown(KeyCode.A))
			rb.MovePosition(rb.position + Vector2.left);
		else if (Input.GetKeyDown(KeyCode.W))
			rb.MovePosition(rb.position + Vector2.up);
		else if (Input.GetKeyDown(KeyCode.S))
			rb.MovePosition(rb.position + Vector2.down);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Car")
		{
            GetComponent<Collider2D>().enabled = false;
            Debug.Log("WE DIED!");
            Score.TotalScore = Score.TotalScore + Score.CurrentScore;
            writeScore = Score.TotalScore.ToString();
			Score.CurrentScore = 0;
            AudioSource splat = GetComponent<AudioSource>();
            splat.Play();
            LIVES--;
            if (LIVES < 0)
            {
                Invoke("GameOver", 1.2f);
                GetComponent<WriteScores>().AddNewScore(Settings.PlayerName, writeScore);
            }
            else
                Invoke("ResetGame", 1.2f);

		}



        if (col.tag == "LeftWall")
        {
            rb.MovePosition(rb.position + Vector2.right);
        }
        if (col.tag == "RightWall")
        {
            rb.MovePosition(rb.position + Vector2.left);
        }
        if (col.tag == "BottomWall")
        {
            rb.MovePosition(rb.position + Vector2.up);
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseTextObject.SetActive(true);
        gameIsPaused = true;
    }
    void ResumeGame()
    {
        pauseTextObject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
