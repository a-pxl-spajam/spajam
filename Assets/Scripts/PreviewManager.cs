using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace EffectsPreview
{
  public class PreviewManager : MonoBehaviour
  {
    [SerializeField]
    private Transform _effectRoot;

    [SerializeField]
    private List<Pair> _effectPair;

    public List<Pair> EffectPair => _effectPair;

    [SerializeField]
    private float scale;

    public static List<IDecoratable> decorations;


    private static PreviewManager _instance;
    public static PreviewManager Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new GameObject("PreviewManager").AddComponent<PreviewManager>();
        }
        return _instance;
      }
    }

    private void Awake()
    {
      if (_instance == null)
      {
        _instance = this;
      }
      else
      {
        Destroy(gameObject);
      }
    }

    private void Start()
    {
      decorations.ForEach(decoration =>
      {
        // idをもとにEffectのprefabを返す
        var obj = decoration.Decorate(_effectPair);
        obj.transform.position *= scale;
        obj.transform.position += _effectRoot.position;
      });
    }

    public void Init(List<IDecoratable> decorations)
    {
    }

  }

}
