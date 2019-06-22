using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EffectsPreview;

public class EditorManager : MonoBehaviour
{

  public static EditorManager instance;

  [SerializeField]
  RectTransform cake;
  [SerializeField]
  RectTransform info;

  public RectTransform Cake
  {
    get
    {
      return cake;
    }
  }

  public RectTransform Info
  {
    get
    {
      return info;
    }
  }

  private List<IDecoratable> decorations = new List<IDecoratable>();

  void Start()
  {
    if (instance != null) Destroy(this);
    instance = this;
    DontDestroyOnLoad(gameObject);
  }

  public void Push(IDecoratable decoration)
  {
    decorations.Add(decoration);
  }

  public void MovePreview()
  {
    StartCoroutine(MoveScene("EffectPreview"));
  }

  IEnumerator MoveScene(string sceneName)
  {
    var opt = SceneManager.LoadSceneAsync(sceneName);
    opt.allowSceneActivation = false;
    while (opt.progress < 0.88889)
    {
      yield return null;
    }
    opt.allowSceneActivation = true;
    PreviewManager.decorations = decorations;
    Destroy(gameObject);
    SceneManager.UnloadScene("Editor");
  }

}
