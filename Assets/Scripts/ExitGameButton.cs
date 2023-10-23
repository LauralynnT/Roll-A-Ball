using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    public Button exitGame;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void ExitGame()
    {
        Application.Quit();
    }
}
