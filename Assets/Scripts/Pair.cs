using UnityEngine;

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