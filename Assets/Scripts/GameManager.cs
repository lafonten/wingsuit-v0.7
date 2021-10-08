using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Objects Area", order = 1)]
    public GameObject player;
    public GameObject player_start;
    public GameObject wind_sqaure;
    public GameObject coin;
    public GameObject trick1;

   

    void Start()
    {
        
    }

    void Update()
    {
       
    }


    public void PlayGame()
    {
        player_start = GameObject.FindWithTag("start");
        player_start.GetComponent<PlayerAnimationEvent>().CanStart = true;
    }



}
