using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderHelper : MonoBehaviour {

    static VolumeSliderHelper _instance;

    public Slider slider;

    public void Awake()
    {
        slider = GetComponent<Slider>();
        instance = this;
    }
    public static VolumeSliderHelper instance
    {
        get;
        set;
    }

}
