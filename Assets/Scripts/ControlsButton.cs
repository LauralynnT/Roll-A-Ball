using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButton : MonoBehaviour
{
    public Button Controls;
    public GameObject ControlsParent;
    public GameObject CreditsPanel;
    public GameObject OptionsPanel;
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
            OptionsPanel.SetActive(false);
            ControlsParent.SetActive(true);
        }
    }
}
