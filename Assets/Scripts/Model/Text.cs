using UnityEngine;
using System.Collections.Generic;

public class Text : IDecoratable
{
  private int id;
  public Vector3 Position { get; set; }

  public GameObject Decorate(List<Pair> effectList)
  {
    throw new System.NotImplementedException();
  }
}
