using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Info : MonoBehaviour
{

  [SerializeField] private GameObject inputFieldObj;
  [SerializeField] private GameObject inspector;
  [SerializeField] private UnityEngine.UI.Text currentTextAreaText;
  [SerializeField] private GameObject currentDecorationObj;
  [SerializeField] private GameObject deletArea;

  // エディタ側のメンバ
  [SerializeField] private UnityEngine.UI.Button enterButton;
  [SerializeField] private UnityEngine.UI.Text skeltonText;
  [SerializeField] private UnityEngine.UI.Text enterText;
  [SerializeField] private UnityEngine.UI.InputField[] vec3InputFields;
  [SerializeField] private UnityEngine.UI.Slider delaySlider;

  public static Info instance;

  void Start()
  {
    enterButton.onClick.AddListener(delegate { OnButtonClicked(); });

    if (instance != null) Destroy(this);
    instance = this;
    DontDestroyOnLoad(gameObject);

  }

  public void OnInputField()
  {
    if (currentDecorationObj != null)
    {
      var decorateObj = currentDecorationObj.GetComponent<DecorateObj>();
      float x, y, z;
      if (vec3InputFields[0].transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text != "")
        x = float.Parse(vec3InputFields[0].transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text);
      else
        x = 0;

      if (vec3InputFields[1].transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text != "")
        y = float.Parse(vec3InputFields[1].transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text);
      else
        y = 0;

      if (vec3InputFields[2].transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text != "")
        z = float.Parse(vec3InputFields[2].transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text);
      else
        z = 0;

      decorateObj.pos = new Vector3(x, y, z) / 10;
      currentDecorationObj.GetComponent<RectTransform>().localPosition = decorateObj.pos + decorateObj.baseLocalPos;
    }
  }

  public void OnChangedSlider()
  {
    var decorateObj = currentDecorationObj.GetComponent<DecorateObj>();
    decorateObj.rotValue = delaySlider.value;
    currentDecorationObj.GetComponent<RectTransform>().localEulerAngles = new Vector3(0.0f, 0.0f, decorateObj.rotValue);
  }

  private void OnButtonClicked()
  {
    if (enterText.text != "")
    {
      var txt = currentDecorationObj.transform.Find("text").GetComponent<UnityEngine.UI.Text>();
      if (txt != null)
      {
        txt.text = enterText.text;
        InitCracker(currentDecorationObj.GetComponent<DecorateObj>());
      }
      inputFieldObj.SetActive(false);
    }
  }
  public void InitTextArea(GameObject obj)
  {
    inputFieldObj.SetActive(true);
    currentDecorationObj = obj;
    currentTextAreaText.text = obj.name.Replace("(Clone)", "");
  }

  public void InitCracker(DecorateObj obj)
  {
    inspector.SetActive(true);
    deletArea.SetActive(true);
    currentDecorationObj = obj.gameObject;
    currentTextAreaText.text = obj.name.Replace("(Clone)", "");
    delaySlider.value = obj.GetComponent<DecorateObj>().rotValue;
  }

  public void Inactive()
  {
    inspector.SetActive(false);
    inputFieldObj.SetActive(false);
    deletArea.SetActive(false);
  }

  public UnityEngine.UI.InputField[] GetPosInputFields()
  {
    return vec3InputFields;
  }

  public void SetDecorateObj(GameObject obj)
  {
    currentDecorationObj = obj;
    currentTextAreaText.text = obj.name.Replace("(Clone)", "");
  }
}
