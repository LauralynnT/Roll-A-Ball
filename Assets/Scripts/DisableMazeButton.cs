using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableMazeButton : MonoBehaviour
{
    public Button button;
    public GameObject mazeObject;
    public GameObject mainWall;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(disableMaze);
    }

    // Update is called once per frame
    void disableMaze()
    {
        mazeObject.SetActive(false);
        mainWall.SetActive(true);
    }
}
