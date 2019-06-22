using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cracker : DecorateObj
{

  Particle particle;

  void Start()
  {
  }

  void Update()
  {
  }

  public override IDecoratable GetDecoratable()
  {
    particle = new Particle();
    return this.particle;
  }
}
