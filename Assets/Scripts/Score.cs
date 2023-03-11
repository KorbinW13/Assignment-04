using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int CurrentScore = 0;
	public static int TotalScore = 0;

	public Text scoreText;
	public Text totalScoreText;

	public Text lifeText;

	void Start ()
	{
		scoreText.text = CurrentScore.ToString();
		totalScoreText.text = "Total Score: " + TotalScore.ToString();
		lifeText.text = "Lives: " + Frog.LIVES.ToString();
	}

}
