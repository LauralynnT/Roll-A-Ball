using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    private int count;
    private int mazeCount;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI mazeCountText;
    public GameObject buttonText;
    public GameObject winTextObject;
    public GameObject winWall;
    public GameObject mazeWinText;
    public GameObject mazeEndWall;
    public GameObject mazeObjectiveText;
    public GameObject mazeShortcut;
    public GameObject mainCamera;
    public GameObject buttonCamera;
    public GameObject finishText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        count = 0;
        mazeCount = 24;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Coins: " + count.ToString();
        mazeCountText.text =mazeCount.ToString();
        if (count == 12)
        {
            winTextObject.SetActive(true);
            winWall.SetActive(false);
        }
        else if (count == 24)
        {
            mazeWinText.SetActive(true);
            mazeEndWall.SetActive(false);
            mazeObjectiveText.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            mazeCount--;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Area1Wall"))
        {

            other.gameObject.SetActive(false);
            winTextObject.SetActive(false);
            mazeObjectiveText.SetActive(true);
        }
        if (other.gameObject.CompareTag("Area2Wall"))
        {
            other.gameObject.SetActive(false);
            mazeWinText.SetActive(false);
            mazeShortcut.SetActive(false);
            mainCamera.SetActive(false);
            buttonCamera.SetActive(true);
            buttonText.SetActive(true);

            if (other.gameObject.CompareTag("RedButton"))
            {
                other.gameObject.SetActive(true);
                if (other.gameObject.CompareTag("CyanButton"))
                {
                    other.gameObject.SetActive(true);
                    if (other.gameObject.CompareTag("GreenButton"))
                    {
                        other.gameObject.SetActive(true);
                        if (other.gameObject.CompareTag("BlueButton"))
                        {
                            other.gameObject.SetActive(true);
                            if (other.gameObject.CompareTag("PinkButton"))
                            {
                                other.gameObject.SetActive(true);
                                if (other.gameObject.CompareTag("OrangeButton"))
                                {
                                    other.gameObject.SetActive(true);
                                    if (other.gameObject.CompareTag("YellowButton"))
                                    {
                                        other.gameObject.SetActive(true);
                                        if (other.gameObject.CompareTag("PurpleButton"))
                                        {
                                            other.gameObject.SetActive(true);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            finishText.SetActive(true);
            buttonText.SetActive(false);
        }
    }
}
