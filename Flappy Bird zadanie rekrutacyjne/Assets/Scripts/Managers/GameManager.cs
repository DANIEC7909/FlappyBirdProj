using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    public  int ThisRunPoints;
    int counter;
    [SerializeField] TextMeshProUGUI points;
<<<<<<< HEAD
<<<<<<< HEAD
 
    [SerializeField] TextMeshProUGUI endPoints;
    [SerializeField] TextMeshProUGUI bombs;
    [SerializeField] GameObject WhilePlayingObjectUI;
  
  
=======
    [SerializeField] TextMeshProUGUI endPoints;
    [SerializeField] TextMeshProUGUI bombs;
    [SerializeField] GameObject WhilePlayingObjectUI;

>>>>>>> parent of 63a124a (poprawki)
=======
    [SerializeField] TextMeshProUGUI endPoints;
    [SerializeField] TextMeshProUGUI bombs;
    [SerializeField] GameObject WhilePlayingObjectUI;

>>>>>>> parent of 63a124a (poprawki)
    public static bool _StartGame;
    #region GameOverVars
    [SerializeField]GameObject GameOverObjectUI;
    #endregion

    private void Start()
    {
        ThisRunPoints = 0;
        player.OnPlayerScored += Player_OnPlayerScored;
        _StartGame = false;
<<<<<<< HEAD
<<<<<<< HEAD
     
=======
>>>>>>> parent of 63a124a (poprawki)
=======
>>>>>>> parent of 63a124a (poprawki)
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
<<<<<<< HEAD
            if(GameOverObjectUI.active  == false) GameOverObjectUI.SetActive(true);
=======
           if(GameOverObjectUI.active==false) GameOverObjectUI.SetActive(true);
     //       SceneManager.LoadScene(0);    //<temp

            //save points etc.

>>>>>>> parent of 63a124a (poprawki)
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
