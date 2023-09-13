using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public int Rotation1;
    public int Rotation2;
    public int Rotation3;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(Rotation1, Rotation2, Rotation3) * Time.deltaTime);
    }
}
