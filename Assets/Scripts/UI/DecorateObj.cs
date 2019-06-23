using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public abstract class DecorateObj : MonoBehaviourPunCallbacks
{

  public abstract IDecoratable GetDecoratable();
  public float delayValue;
  public Vector3 pos;
  public float rotValue;
  public Vector3 baseLocalPos;

}