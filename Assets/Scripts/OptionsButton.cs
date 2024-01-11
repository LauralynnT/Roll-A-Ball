using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    public Button button;
    public GameObject options;
    public GameObject controls;
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OpenOptions);
    }

    // Update is called once per frame
    void OpenOptions()
    {
        if (options.active == true)
        {
            options.SetActive(false);
        }
        else
        {
            options.SetActive(true);
            credits.SetActive(false);
            controls.SetActive(false);
        }
    }
}
