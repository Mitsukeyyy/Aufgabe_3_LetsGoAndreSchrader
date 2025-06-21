using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int counterInt = 0;
    [SerializeField] public int DiamondInt = 1;
    [SerializeField] public int timerInt = 0;
    [SerializeField] private UI_Manager uiManager;
    [SerializeField] private PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counterInt = 0;
        uiManager.UpdateCounter(counterInt);
        StartCoroutine(TimeCount());
    }
    
    public void IncreaseCounter()
    {
        counterInt++;
        uiManager.UpdateCounter(counterInt);
    }
    
    public void IncreaseDiamondCounter()
    {
        DiamondInt++;
        uiManager.UpdateDiamond(DiamondInt);
    }

    IEnumerator TimeCount()
    {
        yield return new WaitForSeconds(3f);
        for (timerInt = 0; ; timerInt++)
        {
            uiManager.UpdateTimer(timerInt);
            yield return new WaitForSeconds(1f);
            Debug.Log("Loop" + timerInt);
        }
    }
}