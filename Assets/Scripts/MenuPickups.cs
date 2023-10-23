using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MenuPickups : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("pickup");
            StartCoroutine(ResetPickup(other.gameObject));
        }
        IEnumerator ResetPickup(GameObject other)
        {
            other.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(2);
            other.gameObject.SetActive(true);
        }
    }
    
}