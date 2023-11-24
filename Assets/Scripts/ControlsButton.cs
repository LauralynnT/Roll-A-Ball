using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButton : MonoBehaviour
{
    public Button Controls;
    public GameObject ControlsParent;
    public GameObject CreditsPanel;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OpenControls);

    }

    // Update is called once per frame
    void OpenControls()
    {
        if (ControlsParent.active == true)
        {
            ControlsParent.SetActive(false);   
        }
        else
        {
            CreditsPanel.SetActive(false);
            ControlsParent.SetActive(true);
        }
    }
}
