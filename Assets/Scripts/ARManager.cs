using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARManager : MonoBehaviour
{

  public static ARManager instance;

  [SerializeField]
  EffectList effectList;

  public static List<IDecoratable> decorations;
  public List<GameObject> particles = new List<GameObject>();
  [SerializeField]
  private float scale;
  [SerializeField]
  private Transform _effectRoot;

  public void Awake()
  {
    if (instance != null)
    {
      Destroy(gameObject);
    }

    instance = this;
  }

  public void Start()
  {
    decorations.ForEach(x =>
    {
      var obj = x.Decorate(effectList.EffectPair);
      obj.transform.position *= scale;
      obj.transform.position += _effectRoot.position;
      obj.transform.SetParent(_effectRoot);
      particles.Add(obj);
    });
  }

  public void MoveEditor()
  {
    StartCoroutine(MoveScene("AR"));
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
