using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsPauseButton : MonoBehaviour
{
    public Button ControlsButton;
    public GameObject controlsContainer;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OpenControls);
    }

    // Update is called once per frame
    void OpenControls()
    {
        if (controlsContainer.active == true)
        {
            controlsContainer.SetActive(false);
        }
        else
        {
            controlsContainer.SetActive(true);
        }
    }
}
