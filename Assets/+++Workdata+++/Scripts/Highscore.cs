using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Highscore : MonoBehaviour
{
    [SerializeField] private int[] highscore =  new int[5];
    [SerializeField] TextMeshProUGUI[] highscoreText;

    [SerializeField] UI_Manager uimanager;
    
    [SerializeField] private string levelId = ""; 
    private bool updated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < highscore.Length; i++)
        {
            highscore[i] = PlayerPrefs.GetInt(GetKey(i), 9999);
        }
        updated = false;
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
        if (!updated){
            UpdateHighscore(uimanager.score);
        }
        
    }

    private void UpdateHighscore(int newScore)
    {
        if (newScore >= highscore[highscore.Length - 1])
            return;
        highscore[highscore.Length - 1] = newScore;
        System.Array.Sort(highscore);

        for (int i = 0; i < highscore.Length; i++)
        {
            PlayerPrefs.SetInt(GetKey(i), highscore[i]);
        }
        PlayerPrefs.Save();
        UpdateList();
        updated = true;
             
    }
    private void UpdateList()
    {
        for (int i = 0; i < highscore.Length; i++)
        {
            if (highscore[i] == 9999){
                highscoreText[i].text = "";
            }
            else
            {
                highscoreText[i].text = (i + 1) + ": " + highscore[i].ToString();
            }
        }
    }
    private string GetKey(int index)
    {
        return $"Highscore_{levelId}_{index}";
    }
  
}