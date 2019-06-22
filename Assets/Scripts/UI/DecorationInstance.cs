using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationInstance : MonoBehaviour
{

  [SerializeField]
  DecorateObj decoration;

  [SerializeField]
  Transform instancePoint;

  public void Instance()
  {
    var instance = Instantiate(decoration, instancePoint.position, Quaternion.identity) as DecorateObj;
    instance.transform.parent = instancePoint.parent;
    EditorManager.instance.Push(instance.GetDecoratable());
  }
}
