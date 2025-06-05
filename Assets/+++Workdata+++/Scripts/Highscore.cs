using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    [SerializeField] private int highscore = 0;
    public TextMeshProUGUI highscoreText;

    [SerializeField] UI_Manager uimanager; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", highscore);
        highscoreText.text = highscore.ToString();
     
        
    }

    // Update is called once per frame
    void Update()
    {
        HighscoreSystem();
    }

    private void HighscoreSystem()
    {
        if (highscore < uimanager.score)
        {
            highscore = uimanager.score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
            highscoreText.text = highscore.ToString();
       
        }
    }
}
