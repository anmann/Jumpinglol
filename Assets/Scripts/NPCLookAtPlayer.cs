using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLookAtPlayer : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private GameObject player;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            sprite.flipX = false;
        }
    }
}
