using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePipe : MonoBehaviour
{
    public bool used;//by declares is player fly through the pipes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PipeManager.DestroyPipeAndSpawnNewOne(this);
            used = true; 
        }
    }
    public void DestroyByBomb()
    {
        if (!used)
        {
            PipeManager.DestroyPipeAndSpawnNewOneByBomb(this);
        }
    }
}
