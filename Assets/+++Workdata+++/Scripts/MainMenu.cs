using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button Level1Button;
    [SerializeField] Button Level2Button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Level1Button.onClick.AddListener(Level1);
        Level2Button.onClick.AddListener(Level2);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
}

