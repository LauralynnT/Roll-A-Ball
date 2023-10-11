using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
     void Start()
    {
        
    }
    public void OpenGame()
    {
        SceneManager.LoadScene(1);
    }
}
