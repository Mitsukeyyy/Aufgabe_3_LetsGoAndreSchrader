using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI CountdownText;
    public TextMeshProUGUI scoreDisplay;
 
    public int score;
    
    [SerializeField] GameManager gamemanager;
    
    
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private GameObject winPanel;
    
    [SerializeField] private Button buttonReloadLevel;
    [SerializeField] private Button buttonReloadLevel2;
    [SerializeField] private Button buttonMainMenu1;
    [SerializeField] private Button buttonMainMenu2;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        
      lostPanel.SetActive(false);
      winPanel.SetActive(false);
      timerText.text = "0";
      diamondText.text = "0";

      buttonReloadLevel.onClick.AddListener(LevelRestart);
      buttonReloadLevel2.onClick.AddListener(LevelRestart);
      buttonMainMenu1.onClick.AddListener(StartMenu);
      buttonMainMenu2.onClick.AddListener(StartMenu);
      StartCoroutine(LoadLevel());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    public void ShowLostPanel()
    {
        lostPanel.SetActive(true);
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        PointSystem();
    }

    public void LevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gamemanager.timerInt = 0;
     

    }

    public void UpdateCounter(int CoinCount)
    {
        counter.text = CoinCount.ToString();
    }

    public void UpdateTimer(int TimerInt)
    {
        timerText.text = (TimerInt.ToString() + "s");
    }

    public void UpdateDiamond(int Diamond)
    {
        diamondText.text = (Diamond - 1).ToString();
    }
    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevel()
    {
        for (float i = 3; i > 0; i--)
        {
            CountdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
            
        }
        CountdownText.gameObject.SetActive(false);
    }

    private void PointSystem()
    {
        score =  gamemanager.timerInt / gamemanager.DiamondInt - gamemanager.counterInt; 
        scoreDisplay.text = score.ToString();
    }

}
