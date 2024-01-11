using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audio;
    public void ChangeVolume()
    {
        audio.volume = volumeSlider.value;
    }
}
