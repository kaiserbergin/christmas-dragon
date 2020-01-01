using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollIntro : MonoBehaviour
{
    public float speed = 1.0f;
    private RectTransform _rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.deltaTime;
        _rectTransform.localPosition += new Vector3(0, time * speed, 0f);
    }
}
