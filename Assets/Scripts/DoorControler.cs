using DG.Tweening;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    public GameObject player;
    private int windscore;
    public GameObject doorLeft;
    public GameObject doorRight;

    void Start()
    {
        
    }

    void Update()
    {
        CheckToOpen();
        OpenDoor();
    }

    void OpenDoor()
    {
        if (windscore >= 1 && player.GetComponent<playercontroler>().OnDoor)
        {
            doorRight.transform.DORotate(new Vector3(0, 110, 0), 5f);
            doorLeft.transform.DORotate(new Vector3(0, -110, 0), 5f);
            //RotateLeftDoor();
            //RotateRightDoor();
           player.GetComponent<playercontroler>().OnDoor = false;

        }
    }

    void CheckToOpen()
    {
        windscore = player.GetComponent<playercontroler>().wind_number;
    }

}
