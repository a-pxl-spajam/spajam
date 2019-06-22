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

        public void Init(List<IDecoratable> decorations)
        {
            decorations.ForEach(decoration =>
            {
                // idをもとにEffectのprefabを返す
                var obj = decoration.Decorate();
                print(obj);
                if (obj != null)
                {
                    var deco = Instantiate(obj, _effectRoot);
                }
            });
        }
        
    }

    [System.Serializable]
    public class Pair
    {
        [SerializeField]
        private int _id;
        [SerializeField]
        private GameObject _effect;

        public int Id
        {
            get { return _id; }
        }

        public GameObject Effect
        {
            get { return _effect; }
        }
    }
}
