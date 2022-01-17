using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void Scored();
    public event Scored OnPlayerScored;
    [HideInInspector]
    public int bombsCount=1;
    [SerializeField]
    PlayerModel model;
    Rigidbody2D rb;
    public static bool _PlayerAlive=true;
    #region timer
    [SerializeField] float timer;
    [SerializeField ]int taps;

    #endregion
    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
      
    }
    private void Start()
    {
        _PlayerAlive = true;
    }
    public void Move()
    {
        rb.velocity = Vector2.up * model.ForceMultiplayerUp ;
        taps++;
    }
    private void FixedUpdate()
    {
    transform.position += Vector3.right * model.ForceMultiplayerTowards * Time.deltaTime;
        
    }
    private void Update()
    {
        #region DoubleTap stuff and bomb
        if (taps > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Debug.Log("single tap");
                taps = 0;
                timer = model.doubleClickTime;
            }
            else if (timer > 0 &&taps>1)
            {
                Debug.Log("double tap");
                if (bombsCount >0) { 
                 Collider2D col=Physics2D.OverlapBox(transform.position, new Vector2(model.SizeOfArea, model.SizeOfArea),0);
                    if (col != null)
                    {
                        Debug.Log("colider is :" + col.transform.name);
                        if (col.CompareTag("pipeScore"))
                        {
                            col.GetComponent<SimplePipe>().DestroyByBomb();
                        }
                        else if (col.CompareTag("pipeMistake"))
                        {
                            col.transform.GetComponentInParent<SimplePipe>().DestroyByBomb();
                        }
                    }
                }
                taps = 0;
            } 
        }
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pipeScore"))
        {
            OnPlayerScored?.Invoke();
        }
        else if (collision.CompareTag("pipeMistake"))
        {
            _PlayerAlive = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(model.SizeOfArea, model.SizeOfArea));
    }
}
