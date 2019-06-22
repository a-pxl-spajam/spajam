using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DecorationInstance : MonoBehaviour
{

  [SerializeField]
  DecorateObj decoration;

  [SerializeField]
  Transform instancePoint;
  Info info;

  void Start()
  {
    var btn = GetComponent<Button>();
    info = GameObject.FindObjectOfType<Info>();
    btn.onClick.AddListener(Instance);
  }

  void Instance()
  {
    var instance = Instantiate(decoration, instancePoint.position, Quaternion.identity) as DecorateObj;
    instance.transform.parent = instancePoint.parent;
    EditorManager.instance.Push(instance.GetDecoratable());

    if(instance is TextArea) {
      info.Inactive();
      info.InitTextArea(instance.gameObject);
    } else if(instance is Cracker) {
      info.Inactive();
      info.InitCracker(instance.gameObject);
    }
  }
}
