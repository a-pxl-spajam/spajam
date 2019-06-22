using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EffectsPreview
{
  public class PreviewManager : MonoBehaviour
  {
    [SerializeField]
    private Transform _effectRoot;

    [SerializeField]
    private EffectList _effectPair;

    public EffectList EffectPair => _effectPair;

    [SerializeField]
    private float scale;

    public static List<IDecoratable> decorations;

    public List<GameObject> particles = new List<GameObject>();

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
        var obj = decoration.Decorate(_effectPair.EffectPair);
        obj.transform.position *= scale;
        obj.transform.position += _effectRoot.position;
        particles.Add(obj);
      });
    }

    public void Init(List<IDecoratable> decorations)
    {
    }

    public void MoveEditor()
    {
      StartCoroutine(MoveScene("EffectPreview"));
      particles.ForEach(x => Destroy(x));
      particles.Clear();
    }

    IEnumerator MoveScene(string sceneName)
    {
      var opt = SceneManager.UnloadSceneAsync(sceneName);
      opt.allowSceneActivation = false;
      EditorManager.instance.Canvas.SetActive(true);
      while (opt.progress < 0.88889)
      {
        yield return null;
      }
      opt.allowSceneActivation = true;
    }

  }

}
