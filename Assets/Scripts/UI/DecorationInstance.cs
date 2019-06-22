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

  void Start()
  {
    var btn = GetComponent<Button>();
    btn.onClick.AddListener(Instance);
  }

  void Instance()
  {
    var instance = Instantiate(decoration, instancePoint.position, Quaternion.identity) as DecorateObj;
    instance.transform.parent = instancePoint.parent;
    EditorManager.instance.Push(instance.GetDecoratable());
  }
}
