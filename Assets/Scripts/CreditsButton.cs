using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{
    public Button creditsButton;
    public GameObject creditsPanel;
    public GameObject controlsPanel;
    public GameObject options;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(openCredits);
    }

    // Update is called once per frame
    void openCredits()
    {
        if (creditsPanel.active == false)
        {
            controlsPanel.SetActive(false);
            options.SetActive(false);
            creditsPanel.SetActive(true);
        }
        else
        {
            creditsPanel.SetActive(false);
        }
    }
}
