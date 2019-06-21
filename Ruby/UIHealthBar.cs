using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }
    public Image _mask;
    float _originalSize;

    void Awake(){
        instance =this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _originalSize = _mask.rectTransform.rect.width;

    }
    public void SetValue(float value)
    {
        _mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _originalSize * value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
