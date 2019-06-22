using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EffectsPreview;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace EffectsPreview
{
  public class TestPreviewManager : MonoBehaviour
  {

    [SerializeField] private List<IDecoratable> _testDecorations;

    void Start()
    {
      _testDecorations = new List<IDecoratable>()
            {
                new Particle(1, new Vector3(0f, 0f, 0f), 0f),
                new Particle(2, new Vector3(0.5f, 0.5f, 0.5f), 60f),
                new Particle(3, new Vector3(-0.3f, 0.3f, 0f), 90f),
            };
      PreviewManager.Instance.Init(_testDecorations);
    }

    void Update()
    {

    }
  }
}


