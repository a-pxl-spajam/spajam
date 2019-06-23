using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    float red, green, blue;
    [SerializeField] float speed,reddec,greendec,bluedec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        red = speed*Mathf.Cos(2 * Mathf.PI * 3.0f * Time.realtimeSinceStartup / 3 + 0.0f);
        green=  speed*Mathf.Cos(2 * Mathf.PI * 3.0f * Time.realtimeSinceStartup / 3 + 2.0f);
        blue= speed*Mathf.Cos(2 * Mathf.PI * 3.0f * Time.realtimeSinceStartup / 3 + 4.0f);
        this.GetComponent<Renderer>().material.color = new Color(red/reddec, green/greendec, blue/bluedec);
    }
}
