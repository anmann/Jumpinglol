using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLookAtPlayer : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
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
