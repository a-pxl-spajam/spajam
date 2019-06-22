using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManager : MonoBehaviour
{

  public static EditorManager instance;

  private List<IDecoratable> decorations = new List<IDecoratable>();

  void Start()
  {
    if (instance != null) Destroy(this);
    instance = this;
    DontDestroyOnLoad(gameObject);
  }

  public void Push(IDecoratable decoration)
  {
    decorations.Add(decoration);
  }

}
