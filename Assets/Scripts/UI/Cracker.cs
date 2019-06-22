using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cracker : DecorateObj, IDragHandler, IDropHandler
{

  Particle particle;


  void Start()
  {
  }

  void Update()
  {
  }

  public void OnDrag(PointerEventData data)
  {
    (transform as RectTransform).position = data.position;

    var cake = EditorManager.instance.Cake;
    var pos = transform.position - cake.position;
    pos.z = pos.y;
    pos.y = 0;
    pos = Vector3.Scale(pos, new Vector3(1 / cake.rect.width, 0, 1 / cake.rect.height));
    particle.position = pos;
  }

  public void OnDrop(PointerEventData data)
  {
    var canvasSize = (transform.parent as RectTransform).rect.size;
    if (canvasSize.y * 0.3f > transform.localPosition.y + canvasSize.y / 2)
    {
      Destroy(gameObject);
    }
  }

  public override IDecoratable GetDecoratable()
  {
    particle = new Particle();
    return this.particle;
  }
}
