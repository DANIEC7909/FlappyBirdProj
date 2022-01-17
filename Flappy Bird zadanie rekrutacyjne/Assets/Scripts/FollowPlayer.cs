using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    [SerializeField]
    Transform player;
    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y);
    }
}
