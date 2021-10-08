using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    public GameObject player;
    public GameObject playerStart;
    public bool CanChangeCameraPosition = false;
    private Animator startAnimator;
    public bool CanStart = false;

    void Start()
    {
        startAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Starting();
    }


    void Starting()
    {
        if (CanStart)
        {
            startAnimator.SetTrigger("start");
        }
    }


    void Jump()
    {
       Destroy(playerStart);
       player.SetActive(true);
       CanChangeCameraPosition = true;
    }

}
