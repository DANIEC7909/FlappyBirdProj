using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          
            PipeManager.DestroyPipeAndSpawnNewOne(this);
        }
    }
    public void DestroyByBomb()
    {
        PipeManager.DestroyPipeAndSpawnNewOne(this);
    }
}
