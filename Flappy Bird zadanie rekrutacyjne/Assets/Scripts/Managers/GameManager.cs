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
    public TextMeshProUGUI points;
    public TextMeshProUGUI bombs;
    private void Start()
    {
        ThisRunPoints = 0;
        player.OnPlayerScored += Player_OnPlayerScored;
    }

    private void Player_OnPlayerScored()
    {
        ThisRunPoints++;
        counter++;
        Debug.Log("PlayerScored: "+ThisRunPoints);
    }

    void Update()
    {
        if (!PlayerController._PlayerAlive)
        {
        
            SceneManager.LoadScene(0);    //<temp
            //game failed 

            //save points etc.

        }
        if (counter >= 10)
        {
            counter = 0;
            player.bombsCount++;
        }

        points.text = ThisRunPoints.ToString();
        bombs.text = player.bombsCount.ToString();
    }
}
