using UnityEngine;

public class UserInterFace : MonoBehaviour
{
    public GameObject play_button;
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        play_button.SetActive(false);

    }
}
