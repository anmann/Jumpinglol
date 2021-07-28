using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 1.2f;
    
    private void Update()
    {
        //* Time.deltaTime
        transform.Rotate(0, 0, 360 * speed * Time.fixedDeltaTime);
    }
}
