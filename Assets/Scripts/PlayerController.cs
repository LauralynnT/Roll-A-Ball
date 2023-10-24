using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using System;

public class PlayerController : MonoBehaviour
{
    private int buttonCondition;
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
    public GameObject mainCanvas;
    public GameObject pauseCanvas;
    public GameObject controlsCanvas;
    public GameObject redLight;
    public GameObject orangeLight;
    public GameObject yellowLight;
    public GameObject greenLight;
    public GameObject blueLight;
    public GameObject cyanLight;
    public GameObject pinkLight;
    public GameObject purpleLight;
    public GameObject stairs;
    public GameObject redArch;
    public GameObject orangeArch;
    public GameObject yellowArch;
    public GameObject greenArch;
    public GameObject blueArch;
    public GameObject cyanArch;
    public GameObject pinkArch;
    public GameObject purpleArch;
    public GameObject lights;
    public GameObject redOff;
    public GameObject orangeOff;
    public GameObject yellowOff;
    public GameObject greenOff;
    public GameObject blueOff;
    public GameObject cyanOff;
    public GameObject pinkOff;
    public GameObject purpleOff;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        count = 0;
        mazeCount = 24;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (pauseCanvas.active == true)
            {
                pauseCanvas.SetActive(false);
                mainCanvas.SetActive(true);
            }
            else
            {
                mainCanvas.SetActive(false);
                controlsCanvas.SetActive(false);
                pauseCanvas.SetActive(true);
            }
        }
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
        if (count == 1)
        {
            winTextObject.SetActive(true);
            winWall.SetActive(false);
        }
        else if (count == 2)
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
            lights.SetActive(false);
            StartCoroutine(ArchLights());     
        }
        if (other.gameObject.CompareTag("RedButton"))
        {
            redLight.SetActive(true);
        }
        if (other.gameObject.CompareTag("OrangeButton"))
        {
            orangeLight.SetActive(true);
        }
        if (other.gameObject.CompareTag("YellowButton"))
        {
            yellowLight.SetActive(true);
        }
        if (other.gameObject.CompareTag("GreenButton"))
        {
            greenLight.SetActive(true);
        }
        if (other.gameObject.CompareTag("CyanButton"))
        {
            cyanLight.SetActive(true);
        }
        if (other.gameObject.CompareTag("BlueButton"))
        {
            blueLight.SetActive(true);
        }
        if (other.gameObject.CompareTag("PurpleButton"))
        {
            purpleLight.SetActive(true);
        }
        if (other.gameObject.CompareTag("PinkButton"))
        {
            pinkLight.SetActive(true);
        }
        if (other.gameObject.CompareTag("RedButton") || (buttonCondition == 1 && other.gameObject.CompareTag("CyanButton")) || (buttonCondition == 2 && other.gameObject.CompareTag("GreenButton")) || (buttonCondition == 3 && other.gameObject.CompareTag("BlueButton")) || (buttonCondition == 4 && other.CompareTag("PinkButton")) || (buttonCondition == 5 && other.gameObject.CompareTag("OrangeButton")) || (buttonCondition == 6 && other.gameObject.CompareTag("YellowButton")) || (buttonCondition == 7 && other.gameObject.CompareTag("PurpleButton")))
        {
            buttonCondition ++;
            Debug.Log(buttonCondition);
        }
        else if ((buttonCondition != 0 && other.gameObject.CompareTag("RedButton")) || (buttonCondition != 1 && other.gameObject.CompareTag("CyanButton")) || (buttonCondition != 2 && other.gameObject.CompareTag("GreenButton")) || (buttonCondition != 3 && other.gameObject.CompareTag("BlueButton")) || (buttonCondition != 4 && other.gameObject.CompareTag("PinkButton")) || (buttonCondition != 5 && other.gameObject.CompareTag("OrangeButton")) || (buttonCondition != 6 && other.gameObject.CompareTag("YellowButton")) || (buttonCondition != 7 && other.gameObject.CompareTag("PurpleButton")))
        {
            TurnOffLights();
            buttonCondition = 0;
            Debug.Log(buttonCondition);
        }
        if (buttonCondition == 8)
        {
            stairs.SetActive(true);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            finishText.SetActive(true);
        }
    }
     void TurnOffLights()
    {
        redLight.SetActive(false);
        orangeLight.SetActive(false);
        yellowLight.SetActive(false);
        greenLight.SetActive(false);
        blueLight.SetActive(false);
        cyanLight.SetActive(false);
        pinkLight.SetActive(false);
        purpleLight.SetActive(false);
    }
    private IEnumerator ArchLights()
    {
        redArch.SetActive(true);
        redOff.SetActive(false);
        purpleArch.SetActive(false);
        purpleOff.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        cyanArch.SetActive(true);
        redArch.SetActive(false);
        redOff.SetActive(true);
        cyanOff.SetActive(false);
        yield return new WaitForSecondsRealtime(2);
        greenArch.SetActive(true);
        greenOff.SetActive(false);
        cyanArch.SetActive(false);
        cyanOff.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        blueArch.SetActive(true);
        greenArch.SetActive(false);
        blueOff.SetActive(false);
        greenOff.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        pinkArch.SetActive(true);
        pinkOff.SetActive(false);
        blueArch.SetActive(false);
        blueOff.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        orangeArch.SetActive(true);
        pinkArch.SetActive(false);
        orangeOff.SetActive(false);
        pinkOff.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        yellowArch.SetActive(true);
        orangeArch.SetActive(false);
        yellowOff.SetActive(false);
        orangeOff.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        purpleArch.SetActive(true);
        yellowArch.SetActive(false);
        purpleOff.SetActive(false);
        yellowOff.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
    }
}
