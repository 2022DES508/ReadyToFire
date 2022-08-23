using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public bool isDraw;

    public PoliceAttributes currentPA;
    public GameObject currentLine;

    public int enemyCounter;

    public GameObject GameOver;
    public GameObject GameWin;

    public bool isShowPoliceUI; 
    private void OnEnable()
    {
        if (GameManager.GM == null)
            GameManager.GM = this;
    }

    private void Start()
    {
        isShowPoliceUI = false; 
    }

    private void Update()
    {
        if (currentPA && currentPA.endMove)
        {
            currentPA.endMove = false;
            Destroy(currentLine); 
        }

        CalculateEnemyAmount();
        JudgeEnd();
        CheckIsShowPoliceUI(); 
    }

    void CalculateEnemyAmount() 
    {
        TerroristAttributes[] enemies = FindObjectsOfType<TerroristAttributes>(true);  
        if (enemies != null)
        {
            enemyCounter = enemies.Length;
            // Debug.Log(enemies.Length); 
        }
        else
        {
            enemyCounter = 0; 
        }
    }

    void JudgeEnd()
    {
        if (enemyCounter <= 0)
        {
            GameWin.SetActive(true);
            Time.timeScale = 0f; 
        }

        if (CalculatePoliceAmount() <= 0)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f; 
        }
    }

    int CalculatePoliceAmount()
    {
        PoliceAttributes[] enemies = FindObjectsOfType<PoliceAttributes>();
        if (enemies != null)
        {
            return enemies.Length;
        }
        else
        {
            return 0;
        }
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene("StartMenu"); 
    }

    public void OnClickLevel1()
    {
        SceneManager.LoadScene("LevelDraft"); 
    }

    public void OnClickLevel2()
    {
        SceneManager.LoadScene("Level2Draft");
    }

    public void OnClickLevel3()
    {
        SceneManager.LoadScene("Level3Draft");
    }

    public void OnClickQuit()
    {
        Application.Quit(); 
    }

    void CheckIsShowPoliceUI()
    {
        if (Input.GetKeyDown("space"))
        {
            if (isShowPoliceUI == false)
            {
                isShowPoliceUI = true; 
            }
            else
            {
                isShowPoliceUI = false; 
            }
        }
    }
}
