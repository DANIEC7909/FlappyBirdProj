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
 
    [SerializeField] TextMeshProUGUI endPoints;
    [SerializeField] TextMeshProUGUI bombs;
    [SerializeField] GameObject WhilePlayingObjectUI;
  
  
    public static bool _StartGame;
    #region GameOverVars
    [SerializeField]GameObject GameOverObjectUI;
    #endregion
    
    private void Start()
    {
        ThisRunPoints = 0;
        player.OnPlayerScored += Player_OnPlayerScored;
        _StartGame = false;
     
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
            if (WhilePlayingObjectUI.active == true) WhilePlayingObjectUI.SetActive(false);
            if(GameOverObjectUI.active  == false) GameOverObjectUI.SetActive(true);
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
