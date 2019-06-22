using UnityEngine;

public abstract class DecorateObj : MonoBehaviour
{

  public abstract IDecoratable GetDecoratable();
  public float delayValue;
  public Vector3 pos;
  public float rotValue;
  public Vector3 baseLocalPos;

}