using System;
using System.Net.Mime;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class playercontroler : MonoBehaviour
{

    private Touch touch;
    [Header("Player Features")]
    public float speedModifier;
    public float speedForward;
    public bool CanFly = false;
    public bool CanStart = false;
    public float continuePosition = 0.003f;

    private float startPosition /*continuePosition*/;
    public bool OnTriggerWindSquare = false;
    private Animator playerAnimator;

    public float floatX;
    public GameObject rotateObj;

    private float positionS;
    public float positionsZ;

    public int gold_amount = 0;
    public float upForce;

    public GameObject cam;

    public Transform FinishTransform;

    public bool IsDead = false;

    public float turningTimer;

    public GameObject deadText;

    public float PowerUp;

    public Text gold_text;
    public int gold_number;
    public Text wind_text;
    public int wind_number;

    public bool OnDoor=false;


    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        positionS = transform.position.y;

    }
    void Update()
    {
        controlerWithSwipe();
        AlwaysMove();
        Fall();
        BarrierChecker();
        DeadScreenSettings();
        UpdateHud();
    }

    void controlerWithSwipe()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                this.transform.position += new Vector3(touch.deltaPosition.x * Time.deltaTime * speedModifier, 0, 0);
            }
        }
    }

    void AlwaysMove()
    {
        transform.position += transform.forward * speedForward * Time.deltaTime;
    }

    void Fall()
    {
        startPosition = 3;

        transform.position += -1f * transform.up * continuePosition;

        startPosition -= continuePosition;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "wind_square")
        {
            this.transform.position += transform.up * Mathf.Abs(positionS/PowerUp);
            //this.transform.DOMove(this.transform.position, new Vector3(transform.up.x,transform.position.y,transform.position.z), 0.5f);
            //Debug.Log("vector3 : " + Vector3.Scale(transform.up, new Vector3(0, Mathf.Abs(positionS / 4f))));
            //transform.DOMove(Vector3.Scale(transform.up, new Vector3(0, Mathf.Abs(positionS / 4f), 0)), 1f);
            //this.GetComponent<Rigidbody>().AddForce(transform.up*PowerUp,ForceMode.Force);
            Destroy(other.gameObject);
            OnTriggerWindSquare = true;
            wind_number += 1;
        }

        if (other.gameObject.CompareTag("Gold"))
        {
            gold_number++;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "rotateArea")
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(FinishTransform.position.x - transform.position.x, transform.position.y, FinishTransform.position.z - transform.position.z
            )), turningTimer * Time.deltaTime);
        }
    }

    void BarrierChecker()
    {
        RaycastHit hit;
        Vector3 positionForward = new Vector3(transform.position.x, transform.position.y + 2f - 0.9f, transform.position.z + 2f - 0.1f);
        Vector3 positionDown = new Vector3(transform.position.x, transform.position.y + 1f + 0.7f, transform.position.z + 0.5f);
        Ray rayForward = new Ray(positionForward, transform.forward);
        Ray rayDown = new Ray(positionDown, transform.up * -1f);

        if (Physics.Raycast(rayForward, out hit, 0.5f))
        {
            if (hit.collider.gameObject.tag == "Barrier")
            {
                IsDead = true;
            }
        }

        if (Physics.Raycast(rayDown, out hit, 0.5f))
        {
            if (hit.collider.gameObject.tag == "Ground")
            {
            }
        }

        if (Physics.Raycast(rayForward, out hit, 50f))
        {
            if (hit.collider.gameObject.tag == "door")
            {
                OnDoor = true;
            }
        }

        Debug.DrawRay(positionDown, transform.up * -1f, Color.blue);
        Debug.DrawRay(positionForward, transform.forward, Color.green);
    }

    void DeadScreenSettings()
    {
        if (IsDead)
        {
            deadText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void UpdateHud()
    {
        gold_text.text = gold_number.ToString();
        wind_text.text = wind_number.ToString();
    }
}
