using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oBJECT : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }
}
