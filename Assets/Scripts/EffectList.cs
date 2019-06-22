using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectList : MonoBehaviour
{

  [SerializeField]
  private List<Pair> _effectPair;

  public List<Pair> EffectPair => _effectPair;

}
