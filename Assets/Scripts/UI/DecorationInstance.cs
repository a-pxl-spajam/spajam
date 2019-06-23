﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(Button))]
public class DecorationInstance : MonoBehaviourPunCallbacks
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
    var obj = PhotonNetwork.Instantiate("UI/" + decoration.transform.gameObject.name.Replace("(Clone)", ""), instancePoint.position, Quaternion.identity);
    var instance = obj.GetComponent<DecorateObj>();
    instance.transform.parent = instancePoint.parent;
    EditorManager.instance.Push(instance.GetDecoratable());

    if (instance is TextArea)
    {
      info.Inactive();
      info.InitTextArea(instance.gameObject);
    }
    else if (instance is Cracker)
    {
      info.Inactive();
      info.InitCracker(instance);
    }
  }
}
