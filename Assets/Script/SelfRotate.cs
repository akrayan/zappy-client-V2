using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public float Speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -10 * Speed) * Time.deltaTime);
    }
}
