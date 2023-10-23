using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGame : MonoBehaviour
{
    public Button ResumeButton;
    public GameObject mainCanvas;
    public GameObject pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Resume);
    }
    void Resume()
    {
        mainCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }
}
