using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Player Player;
    [SerializeField] private Slider Slider;    

    protected void SetMaxValue(float value)
    {
        Slider.maxValue = value;        
    }

    protected void SetValue(float value)
    {
        Slider.value = value;
    }
}
