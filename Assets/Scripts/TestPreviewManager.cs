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

public class Particle : IDecoratable
{
    private int id;
    private Vector3 position;
    private float rotate;

    public int Id => id;
    public Vector3 Position => position;
    public float Rotate => rotate;

    public Particle(int id, Vector3 pos, float rotate)
    {
        this.id = id;
        this.position = pos;
        this.rotate = rotate;
    }
    
    public GameObject Decorate()
    {
        Debug.Log(PreviewManager.Instance.EffectPair);
        var tmp = PreviewManager.Instance.EffectPair
            .Find(pair => pair.Id == this.id)
            .Effect;
            
            return tmp;
            
    }
}

//public class Text : IDecoratable
//{
//    private int id;
//  Vector3 position;
//
//  public GameObject Create()
//  {
//    return null;
//  }
//
//  public GameObject Decorate()
//  {
//      throw new System.NotImplementedException();
//  }
//} 
