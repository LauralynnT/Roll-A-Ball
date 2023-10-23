using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public Button MainButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(SwitchMenu);
    }

    // Update is called once per frame
    void SwitchMenu()
    {
        SceneManager.LoadScene(0);
    }
}
