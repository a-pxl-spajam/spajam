using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowingDelayValue : MonoBehaviour {

    [SerializeField] private float m_constant;
    [SerializeField] private UnityEngine.UI.Text m_text;
    [SerializeField] private Slider m_slider;

    void Start() {
        m_slider.onValueChanged.AddListener(delegate { RewriteText(); });
    }

    private void RewriteText() {
        m_text.text = string.Format("{0:#0.0}", m_constant * m_slider.value);
    }
}
