using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float coinX;
    public float coinY;
    public float coinZ;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(coinX,coinY,coinZ);
    }
}
