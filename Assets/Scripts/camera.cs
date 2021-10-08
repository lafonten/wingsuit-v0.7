using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public PlayerAnimationEvent pAE;
    public bool rotationArea = false;

    void Start()
    {

    }

    void Update()
    {
        FollowObjectChanger();
    }

    void FollowObjectChanger()
    {
        if (pAE.CanChangeCameraPosition)
        {

            GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
            GetComponent<CinemachineVirtualCamera>().LookAt = player.transform;
        }
    }

}
