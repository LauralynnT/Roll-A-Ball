using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCubeButton : MonoBehaviour
{
    public Button resetButton;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ResetBox);
    }

    // Update is called once per frame
    void ResetBox()
    {
        box.transform.position = new Vector3(0.0f, 0.5f, 5.0f);
    }
}
