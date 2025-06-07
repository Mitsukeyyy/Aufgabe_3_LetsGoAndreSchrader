using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    [SerializeField] private int[] highscore =  new int[5];
    //[SerializeField] private int highscore2 = 9999;
    [SerializeField] TextMeshProUGUI[] highscoreText;
    //public TextMeshProUGUI HighscoreText2;

    [SerializeField] UI_Manager uimanager; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < highscore.Length; i++)
        {
            highscore[i] = PlayerPrefs.GetInt("Highscore" + i, 9999);
        }
        
        UpdateList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Press 'R' to reset
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs cleared.");
        }

        UpdateHighscore(uimanager.score);
        
    }

    private void UpdateHighscore(int newScore)
    {
            if (newScore >= highscore[highscore.Length - 1])
                return;
            
            for (int i = 0; i < highscore.Length; i++)
            {
                if (highscore[i] == newScore)
                    return;
            }
            highscore[highscore.Length - 1] = newScore;
            System.Array.Sort(highscore);
            
            for (int i = 0; i < highscoreText.Length; i++)
            {
                PlayerPrefs.SetInt("Highscore" + i, highscore[i]);
            }
            PlayerPrefs.Save();
            UpdateList();
             
    }
    private void UpdateList()
    {
        for (int i = 0; i < highscore.Length && i < highscoreText.Length; i++)
        {
                highscoreText[i].text = highscore[i].ToString();
        }
    }
  
}
