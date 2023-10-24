using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2Button : MonoBehaviour
{
    public Button nextLevelButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(NextLevel);
    }

    // Update is called once per frame
    void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
