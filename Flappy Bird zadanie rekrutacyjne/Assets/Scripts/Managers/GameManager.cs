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
    [SerializeField] TextMeshProUGUI points;
    [SerializeField] TextMeshProUGUI[] highestPointsUGUI= new TextMeshProUGUI[5];
    [SerializeField] TextMeshProUGUI endPoints;
    [SerializeField] TextMeshProUGUI bombs;
    [SerializeField] GameObject WhilePlayingObjectUI;
    [SerializeField] static List<int> HighScores;
    [SerializeField] List<int>nonHighScores;
  
    public static bool _StartGame;
    #region GameOverVars
    [SerializeField]GameObject GameOverObjectUI;
    #endregion
    
    private void Start()
    {
        ThisRunPoints = 0;
        player.OnPlayerScored += Player_OnPlayerScored;
        _StartGame = false;
        HighScores = new List<int>();
    }

    private void Player_OnPlayerScored()
    {
        ThisRunPoints++;
        counter++;
       
    }

    void Update()
    {
        nonHighScores = HighScores;
        if (HighScores.Count >= 1) highestPointsUGUI[0].text = HighScores[0].ToString();
        if (HighScores.Count >= 2) highestPointsUGUI[1].text = HighScores[1].ToString();
        if (HighScores.Count >= 3) highestPointsUGUI[2].text = HighScores[2].ToString();
        if (HighScores.Count >= 4) highestPointsUGUI[3].text = HighScores[3].ToString();
        if (HighScores.Count >= 5) highestPointsUGUI[4].text = HighScores[4].ToString();
        if (!PlayerController._PlayerAlive)
        {
            if (WhilePlayingObjectUI.active == true) WhilePlayingObjectUI.SetActive(false);
           if(GameOverObjectUI.active==false) GameOverObjectUI.SetActive(true);
         
           
            if( !HighScores.Contains(ThisRunPoints))
            {
                if (HighScores.Count >= 5) { 
                    HighScores.Remove(HighScores.Min());
                    Debug.Log("count " + HighScores.Count);
                    if (ThisRunPoints > HighScores.Max())//add only when points from run is > than max value in list
                    {
                        HighScores.Add(ThisRunPoints);

                       
                    }
                }
                else
                {
                    HighScores.Add(ThisRunPoints);

                }
            }
         
          


        }
        else
        {
            if (WhilePlayingObjectUI.active == false) WhilePlayingObjectUI.SetActive(true);
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
   public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        _StartGame = true;
    }
}
