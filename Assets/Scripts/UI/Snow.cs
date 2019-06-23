using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Snow: DecorateObj, IDragHandler, IDropHandler
{
    
  [SerializeField]
  int id;

  Particle particle;


  void Start()
  {
    baseLocalPos = GetComponent<RectTransform>().localPosition;
  }

  void Update()
  {
    particle.Rotate = rotValue;
  }

  public void OnDrag(PointerEventData data)
  {
    Info.instance.SetDecorateObj(gameObject);
    (transform as RectTransform).position = data.position;

    var cake = EditorManager.instance.Cake;
    var pos = transform.position - cake.position;
    pos.z = pos.y;
    pos.y = 0;
    pos = Vector3.Scale(pos, new Vector3(1 / cake.rect.width, 0, 1 / cake.rect.height));
    particle.Position = pos;
    var inputFields = Info.instance.GetPosInputFields();
    string x, y, z;
    var localPos = (transform.localPosition - baseLocalPos);
    inputFields[0].text = "" + localPos.x;
    inputFields[1].text = "" + localPos.y;
    inputFields[2].text = "" + localPos.z;
  }

  public void OnDrop(PointerEventData data)
  {
    var canvasSize = (transform.parent as RectTransform).rect.size;
    if (canvasSize.y * 0.3f > transform.localPosition.y + canvasSize.y / 2)
    {
      EditorManager.instance.Remove(particle);
      Destroy(gameObject);
    }
  }

  public override IDecoratable GetDecoratable()
  {
    particle = new Particle(id, Vector3.zero, 0);
    return this.particle;
  }
}
