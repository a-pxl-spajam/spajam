using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;
using Photon.Pun;
using Photon.Realtime;

public class ARManager : MonoBehaviourPunCallbacks, IPunObservable
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

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
      if(stream.IsWriting) {
        stream.SendNext(decorations.ToArray());
      } else {
        decorations = new List<IDecoratable>( (IDecoratable[])stream.ReceiveNext() );
      }
    }

  public void MoveEditor()
  {
    StartCoroutine(MoveScene("AR"));
    particles.ForEach(x => PhotonNetwork.Destroy(x));
    particles.Clear();
  }

  IEnumerator MoveScene(string sceneName)
  {
    var opt = SceneManager.UnloadSceneAsync(sceneName);
    opt.allowSceneActivation = false;
    PhotonNetwork.Destroy(GameObject.FindObjectOfType<ImageTargetBehaviour>().gameObject);
    EditorManager.instance.Canvas.SetActive(true);
    while (opt.progress < 0.88889)
    {
      yield return null;
    }
    opt.allowSceneActivation = true;
  }

}
