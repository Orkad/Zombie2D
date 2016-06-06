using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Text display { get { return GetComponentInChildren<Text>(); } }
    public RectTransform rectTransform { get { return GetComponent<RectTransform>(); } }
    public Image fill;
    public Color fillColor { set { fill.GetComponent<Image>().color = value; } }
    public float value;
    public float minValue;
    public float maxValue;
    public string endString;
    public string floatToStringParam = "F0";
    public bool disableText = false;
    public bool showMaxValueText = false;


    void Start()
    {
        if (display) display.text = "";
    }

    protected void Update()
    {
        value = Mathf.Clamp(value, minValue, maxValue);
        fill.fillAmount = value/maxValue;
        if (display)
        {
            display.text = value.ToString(floatToStringParam);
            if (showMaxValueText)
                display.text += "/" + maxValue.ToString(floatToStringParam);
            display.text += endString;
        }
        
    }
}


public static class MathExt
{
    public static float Evaluate(float ratio, float min, float max, bool clamped = true)
    {
        if (clamped)
            ratio = Mathf.Clamp01(ratio);
        return (max - min) * ratio + min;
    }

    public static float Ratio(float value, float min, float max, bool clamped = true)
    {
        if (clamped)
            value = Mathf.Clamp(value, min, max);
        return (value - min) / (max - min);
    }

    public static float InverseRatio(float value, float min, float max, bool clamped = true)
    {
        return 1 - Ratio(value, min, max, clamped);
    }

    public static float RandomByPercent(this float value, float percent)
    {
        float maxValue = value + value * percent / 100f;
        float minValue = value - value * percent / 100f;
        return UnityEngine.Random.Range(minValue, maxValue);
    }
}