using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    public  int ThisRunPoints;
    int counter;
    public static bool _StartGame;
    #region GameOverVars
    [SerializeField]GameObject GameOverObjectUI;
    #endregion
    [Space]
    #region UI
    [Header("UI's")]
    [Space]
    [SerializeField] TextMeshProUGUI points;
    [SerializeField] TextMeshProUGUI endPoints;
    [SerializeField] TextMeshProUGUI bombs;
    [SerializeField] TextMeshProUGUI[] highScoresUI;
    [SerializeField] GameObject WhilePlayingObjectUI;
    [SerializeField] GameObject newHighScoreImgUI;
    #endregion
    
    #region saveLoadDataSystem
    [Space]
    SaveScore saveMachine;
   [SerializeField] List<int> loadedData;
    bool saveDataOnlyOnce=true;
    #endregion

    private void Start()
    {
        ThisRunPoints = 0;
        player.OnPlayerScored += Player_OnPlayerScored;
        _StartGame = false;
        saveMachine = new SaveScore();
        if (saveMachine.LoadScores() != null)
        {
            loadedData=saveMachine.LoadScores();
        }
        saveDataOnlyOnce = true;
        newHighScoreImgUI.SetActive(false);
    }

    private void Player_OnPlayerScored()
    {
        ThisRunPoints++;
        counter++;
       
    }

    void Update()
    {



        if (!PlayerController._PlayerAlive)
        {
            //game failed 
            if (WhilePlayingObjectUI.active == true) WhilePlayingObjectUI.SetActive(false);

            if (GameOverObjectUI.active == false) GameOverObjectUI.SetActive(true);

            if (saveDataOnlyOnce)
            {
                loadDataToLoaded();
                //scores stuff
                if (!loadedData.Contains(ThisRunPoints))
                {
                    if (loadedData.Count > 0)
                    {
                        if (ThisRunPoints > loadedData.Max())
                        {
                            saveMachine.saveScores(ThisRunPoints);
                            Debug.Log("NEW HIGH SCORE " + ThisRunPoints);
                        }
                    }
                    else
                    {
                        saveMachine.saveScores(ThisRunPoints); //this piece can be run only once.
                        Debug.Log("NEW HIGH SCORE " + ThisRunPoints);
                        newHighScoreImgUI.SetActive(true);
                    }
                    loadDataToLoaded();
                    List<int> localHighScore = new List<int>();
                    for (int i = 0; i < 5; i++)
                    {
                        if (loadedData.Count > 0)
                        {
                            int MaxNum = loadedData.Max();
                            localHighScore.Add(MaxNum);
                            highScoresUI[i].text = i + 1 + ". " + localHighScore[i].ToString();
                            loadedData.Remove(MaxNum);

                            Debug.Log("maxNum is:" + MaxNum);
                        }
                    }


                }
                saveDataOnlyOnce = false;
            }

        }
        else
        {
            if (_StartGame)
            {
                if (WhilePlayingObjectUI.active == false) WhilePlayingObjectUI.SetActive(true);
            }
        }
        if (counter >= 10)
        {
            counter = 0;
            player.bombsCount++;
        }
        if (player.bombsCount > 3)
        {
            player.bombsCount = 3;
        }
        points.text = ThisRunPoints.ToString();
        endPoints.text = ThisRunPoints.ToString();
        bombs.text = player.bombsCount.ToString();
    }
    void loadDataToLoaded()
    {
        if (saveMachine.LoadScores() != null)
        {
            loadedData = saveMachine.LoadScores();
        }
    }
   public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        _StartGame = true;
    }
}
