using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapToGrid : MonoBehaviour
{
#if UNITY_EDITOR
    public bool snapToGrid = true;
    public float snapValue = 0.5f;

    public bool sizeToGrid = false;
    public float sizeValue = 0.25f;

    private void Update()
    {
        if (snapToGrid)
        {
            transform.position = RoundTransform(transform.position, snapValue);
        }

        if (sizeToGrid)
        {
            transform.localScale = RoundTransform(transform.localScale, sizeValue);
        }
    }

    private Vector3 RoundTransform(Vector3 v, float snapValue)
    {
        return new Vector3
            (
                snapValue * Mathf.Round(v.x / snapValue),
                snapValue * Mathf.Round(v.y / snapValue),
                v.z
            );
    }
#endif
}
