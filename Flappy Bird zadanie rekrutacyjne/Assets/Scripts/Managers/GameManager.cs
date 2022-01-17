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
    [SerializeField] TextMeshProUGUI endPoints;
    [SerializeField] TextMeshProUGUI bombs;
    [SerializeField] GameObject WhilePlayingObjectUI;

    #region GameOverVars
    [SerializeField]GameObject GameOverObjectUI;
    #endregion

    private void Start()
    {
        ThisRunPoints = 0;
        player.OnPlayerScored += Player_OnPlayerScored;
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
            WhilePlayingObjectUI.SetActive(false);
            GameOverObjectUI.SetActive(false);
            SceneManager.LoadScene(0);    //<temp

            //save points etc.

        }
        else
        {
            WhilePlayingObjectUI.SetActive(true);
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

    }
}
