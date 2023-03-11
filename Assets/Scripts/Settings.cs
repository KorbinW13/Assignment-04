using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject settingsTextObject;
    public GameObject scoresTextObject;

    public Text SpeedText;
    public Slider CarSpeedSlider;
    public static float CarSpeed = 10f;

    public Text SpawnText;
    public Slider CarSpawnSlider;
    public static float SpawnDelay = 0.3f;

    public static string PlayerName = "AAA";
    public InputField PlayerNameInput;
    public Text showPlayerName;

    bool settingsEnabled = false;
    bool scoresEnabled = false;

    void Start()
    {
        settingsEnabled = false;
        CarSpeedSlider.value = CarSpeed;
        CarSpawnSlider.value = SpawnDelay;
        PlayerNameInput.text = PlayerName;
    }

    public void UpdateName()
    {
        PlayerName = PlayerNameInput.text;
        Debug.Log(PlayerName);
        showPlayerName.text = PlayerName;
    }

    public void ButtonBool()
    {
        settingsEnabled = !settingsEnabled;
        settingsTextObject.SetActive(settingsEnabled);
    }
    public void ScoreBool()
    {
        scoresEnabled = !scoresEnabled;
        scoresTextObject.SetActive(scoresEnabled);
    }

    public void CarSpeed_Slider()
    {
        SpeedText.text = "Car Speed: " + CarSpeedSlider.value + " to " + (CarSpeedSlider.value + CarSpeedSlider.value);
        Debug.Log(CarSpeedSlider.value);
        CarSpeed = CarSpeedSlider.value;
    }

    public void CarSpawn_Slider()
    {
        SpawnText.text = "Spawn Speed: " + float.Parse(CarSpawnSlider.value.ToString("F2")) + " Sec Delay";
        Debug.Log(float.Parse(CarSpawnSlider.value.ToString("F2")));
        SpawnDelay = float.Parse(CarSpawnSlider.value.ToString("F2"));
    }

}
