using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPatternButton : MonoBehaviour
{
    public Button restartPatternButton;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ResetPattern);
    }

    // Update is called once per frame
    void ResetPattern()
    {
        cube.SetActive(true);
    }
}
