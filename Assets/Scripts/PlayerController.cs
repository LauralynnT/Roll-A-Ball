using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int buttonCondition;
    private int mazeCount;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public int count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI mazeCountText;
    public GameObject buttonText;
    public GameObject winTextObject;
    public GameObject winWall;
    public GameObject mazeWinText;
    public GameObject mazeEndWall;
    public GameObject mazeObjectiveText;
    public GameObject puzzleText;
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
    public GameObject continueText;
    public GameObject patternButton;
    public GameObject theCube;
    public GameObject disableMazeButton;
    public GameObject enableMazeButton;
    public GameObject redTrigger;
    public GameObject orangeTrigger;
    public GameObject yellowTrigger;
    public GameObject greenTrigger;
    public GameObject blueTrigger;
    public GameObject cyanTrigger;
    public GameObject pinkTrigger;
    public GameObject purpleTrigger;
    private AudioSource SFX;
    public AudioClip rollSFX;
    // Start is called before the first frame update
    void Start()
    {
        SFX = GetComponent<AudioSource>();
        rb = GetComponent <Rigidbody>();
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
                Time.timeScale = 1;
            }
            else
            {
                mainCanvas.SetActive(false);
                controlsCanvas.SetActive(false);
                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (theCube.active == true)
        {
            StartCoroutine(ArchLights());
        }
    }
    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        SFX.PlayOneShot(rollSFX);
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
            mazeShortcut.SetActive(false);
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
            disableMazeButton.SetActive(true);
        }
        if (other.gameObject.CompareTag("Area2Wall"))
        {
            other.gameObject.SetActive(false);
            mazeWinText.SetActive(false);
            mazeShortcut.SetActive(false);
            puzzleText.SetActive(true);
            mainCamera.SetActive(false);
            buttonCamera.SetActive(true);
            lights.SetActive(false);
            enableMazeButton.SetActive(false);
            disableMazeButton.SetActive(false);
            StartCoroutine(ArchLights());
        }
        if (other.gameObject.CompareTag("Area3Wall"))
        {
            mainCamera.SetActive(true);
            buttonCamera.SetActive(false);
            lights.SetActive(true);
        }
        if (other.gameObject.CompareTag("RedButton"))
        {
            redLight.SetActive(true);
            if (buttonCondition == 0)
            {
                buttonCondition++;
                redTrigger.SetActive(false);
                Debug.Log("button condition: " + buttonCondition);
            }
            else
            {
                TurnOffLights();
            }
        }
        if (other.gameObject.CompareTag("OrangeButton"))
        {
            orangeLight.SetActive(true);
            if (buttonCondition == 5)
            {
                buttonCondition++;
                orangeTrigger.SetActive(false);
                Debug.Log("button condition: " + buttonCondition);
            }
            else
            {
                TurnOffLights();
            }
        }
        if (other.gameObject.CompareTag("YellowButton"))
        {
            yellowLight.SetActive(true);
            if (buttonCondition == 6)
            {
                buttonCondition++;
                yellowTrigger.SetActive(false);
                Debug.Log("button condition: " + buttonCondition);
            }
            else
            {
                TurnOffLights();
            }
        }
        if (other.gameObject.CompareTag("GreenButton"))
        {
            greenLight.SetActive(true);
            if (buttonCondition == 2)
            {
                buttonCondition++;
                greenTrigger.SetActive(false);
                Debug.Log("button condition: " + buttonCondition);
            }
            else
            {
                TurnOffLights();
            }
        }
        if (other.gameObject.CompareTag("CyanButton"))
        {
            cyanLight.SetActive(true);
            if (buttonCondition == 1)
            {
                buttonCondition++;
                cyanTrigger.SetActive(false);
                Debug.Log("button condition: " + buttonCondition);
            }
            else
            {
                TurnOffLights();
            }
        }
        if (other.gameObject.CompareTag("BlueButton"))
        {
            blueLight.SetActive(true);
            if (buttonCondition == 3)
            {
                buttonCondition++;
                blueTrigger.SetActive(false);
                Debug.Log("button condition: " + buttonCondition);
            }
            else
            {
                TurnOffLights();
            }
        }
        if (other.gameObject.CompareTag("PurpleButton"))
        {
            purpleLight.SetActive(true);
            if (buttonCondition == 7)
            {
                buttonCondition++;
                purpleTrigger.SetActive(false);
                Debug.Log("button condition: " + buttonCondition);
            }
            else
            {
                TurnOffLights();
            }
        }
        if (other.gameObject.CompareTag("PinkButton"))
        {
            pinkLight.SetActive(true);
            if (buttonCondition == 4)
            {
                buttonCondition++;
                pinkTrigger.SetActive(false);
                Debug.Log("button condition: " + buttonCondition);
            }
            else 
            { 
                TurnOffLights(); 
            }
        }
        if (buttonCondition == 8)
        {
            stairs.SetActive(true);
        }
        if (other.gameObject.CompareTag("Finish") && count == 32)
        {
            finishText.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Finish") && count < 32)
        {
            continueText.SetActive(true);
        }
    }
     void TurnOffLights()
    {
        buttonCondition = 0;
        redLight.SetActive(false);
        orangeLight.SetActive(false);
        yellowLight.SetActive(false);
        greenLight.SetActive(false);
        blueLight.SetActive(false);
        cyanLight.SetActive(false);
        pinkLight.SetActive(false);
        purpleLight.SetActive(false);
        redTrigger.SetActive(true);
        orangeTrigger.SetActive(true);
        yellowTrigger.SetActive(true);
        greenTrigger.SetActive(true);
        blueTrigger.SetActive(true);
        cyanTrigger.SetActive(true);
        pinkTrigger.SetActive(true);
        purpleTrigger.SetActive(true);
    }
    public IEnumerator ArchLights()
    {
        theCube.SetActive(false);
        patternButton.SetActive(false);
        redArch.SetActive(true);
        redOff.SetActive(false);
        purpleArch.SetActive(false);
        purpleOff.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        cyanArch.SetActive(true);
        redArch.SetActive(false);
        redOff.SetActive(true);
        cyanOff.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        greenArch.SetActive(true);
        greenOff.SetActive(false);
        cyanArch.SetActive(false);
        cyanOff.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        blueArch.SetActive(true);
        greenArch.SetActive(false);
        blueOff.SetActive(false);
        greenOff.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        pinkArch.SetActive(true);
        pinkOff.SetActive(false);
        blueArch.SetActive(false);
        blueOff.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        orangeArch.SetActive(true);
        pinkArch.SetActive(false);
        orangeOff.SetActive(false);
        pinkOff.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        yellowArch.SetActive(true);
        orangeArch.SetActive(false);
        yellowOff.SetActive(false);
        orangeOff.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        purpleArch.SetActive(true);
        yellowArch.SetActive(false);
        purpleOff.SetActive(false);
        yellowOff.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        purpleArch.SetActive(false);
        purpleOff.SetActive(true);    
        patternButton.SetActive(true);
    }
}
