using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateSlider : MonoBehaviour
{
    private Slider slider;
    private TMP_Text textSlider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        textSlider = transform.Find("TextSlider").gameObject.GetComponent<TMP_Text>();
        textSlider.text = slider.value.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSliderTextLine()
    {
        textSlider.text = slider.value.ToString();
        PersistenceManager.Instance.maxLine = Mathf.FloorToInt(slider.value);
    }

    public void UpdateSliderTextSpeed()
    {
        textSlider.text = slider.value.ToString();
        PersistenceManager.Instance.paddleSpeed = slider.value;
    }
    public void UpdateSliderTextAccel()
    {
        textSlider.text = slider.value.ToString();
        PersistenceManager.Instance.accel = slider.value;
    }
}
