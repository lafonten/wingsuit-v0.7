using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind_square : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rotation();
    }

    void Rotation()
    {
        transform.Rotate(2,2,2);
    }
}
