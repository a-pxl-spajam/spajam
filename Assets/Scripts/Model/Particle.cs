using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : IDecoratable
{
  public Vector3 position { get; set; }
  public float rotate { get; set; }

  public GameObject Create()
  {
    return null;
  }

}
