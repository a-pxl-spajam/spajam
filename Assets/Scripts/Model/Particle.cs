using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : IDecoratable
{
  private int id;
  private float rotate;

  public int Id => id;
  public Vector3 Position { get; set; }
  public float Rotate { get; set; }

  public Particle(int id, Vector3 pos, float rotate)
  {
    this.id = id;
    this.Position = pos;
    this.Rotate = rotate;
  }

  public GameObject Decorate(List<Pair> effectList)
  {
    var eff = effectList.Find(x => x.Id == id);
    if (eff != null)
    {
      return GameObject.Instantiate(eff.Effect, this.Position, Quaternion.Euler(0, this.Rotate, 0));
    }
    else
    {
      return null;
    }
  }
}
