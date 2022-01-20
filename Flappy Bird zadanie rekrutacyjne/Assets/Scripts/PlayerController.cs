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
    [SerializeField] AudioSource aS;
   [SerializeField] AudioSource aScore;
    bool audioIsdead;
    public static bool _PlayerAlive=true;
    #region timer
    [SerializeField] float timer;
    [SerializeField ]int taps;

    #endregion
    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        _PlayerAlive = true;
        audioIsdead = false;
    }
    private void Start()
    {
       
    }
    public void Move()
    {
        if (GameManager._StartGame)
        {
            rb.velocity = Vector2.up * model.ForceMultiplayerUp*Time.deltaTime;
            taps++;
            aS.clip = model.clips[4];
            aS.Play();
        }
    }
    private void FixedUpdate()
    {
        if (GameManager._StartGame)
        {
            transform.position += Vector3.right * model.ForceMultiplayerTowards * Time.deltaTime;
        }
    }
    private void Update()
    {
        if (GameManager._StartGame)
        {
            if (rb.bodyType == RigidbodyType2D.Static)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }

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
                else if (timer > 0 && taps > 1)
                {
                    Debug.Log("double tap");
                    if (bombsCount > 0)
                    {
                        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, model.SizeOfArea);
                        if (col != null)
                        {
                            bool decBombCount = false ;
                            Debug.Log("How much colliders in array:" + col.Length);
                            foreach (Collider2D coll in col)
                            {
                                if (coll.CompareTag("pipeMistake"))
                                {
                                    Debug.Log("colider is :" + coll.transform.name);
                                    coll.GetComponentInParent<SimplePipe>().DestroyByBomb();
                                    if (!decBombCount) {
                                        bombsCount--;
                                        decBombCount = true;
                                        aS.clip = model.clips[1];
                                        aS.Play();
                                    }                                 
                                }
                            }
                        }
                    }
                    taps = 0;
                }
            }
            #endregion
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pipeScore"))
        {
            OnPlayerScored?.Invoke();
            if (!audioIsdead)
            {
                aScore.clip = model.clips[2];
                aScore.Play();
                
            }
        }      
        else if (collision.CompareTag("pipeMistake"))
        {
            _PlayerAlive = false;
            if (!audioIsdead)
            {
                aScore.clip = model.clips[0];
                aScore.Play();
                audioIsdead = true;
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, model.SizeOfArea);
    }
}
