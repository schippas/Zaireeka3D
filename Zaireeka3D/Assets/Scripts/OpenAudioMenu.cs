using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class OpenAudioMenu : MonoBehaviour
{

    public GameObject modalPanel;
    public GameObject source;

    public GameObject volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        modalPanel.SetActive(false);
        volumeSlider.GetComponent<Slider>().onValueChanged.Equals(source);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
