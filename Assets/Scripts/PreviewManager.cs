using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

namespace EffectsPreview
{
  public class PreviewManager : MonoBehaviourPunCallbacks, IPunObservable
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

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
      if(stream.IsWriting) {
        stream.SendNext(decorations.ToArray());
      } else {
        decorations = new List<IDecoratable>( (IDecoratable[])stream.ReceiveNext() );
      }
    }

    public void Init(List<IDecoratable> decorations)
    {
    }

    public void MoveEditor()
    {
      StartCoroutine(MoveScene("EffectPreview"));
      particles.ForEach(x => PhotonNetwork.Destroy(x));
      particles.Clear();
    }

    public void MoveAR()
    {
      StartCoroutine(MoveARScene());
      particles.ForEach(x => PhotonNetwork.Destroy(x));
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

    IEnumerator MoveARScene()
    {
      var opt = SceneManager.LoadSceneAsync("AR", LoadSceneMode.Additive);
      SceneManager.UnloadSceneAsync("EffectPreview");
      opt.allowSceneActivation = false;
      while (opt.progress < 0.88889)
      {
        yield return null;
      }
      opt.allowSceneActivation = true;
      ARManager.decorations = decorations;
    }

  }
}
