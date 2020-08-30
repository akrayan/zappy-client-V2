using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public Material Outline;
    Material old;
    // Start is called before the first frame update
    void Start()
    {
        old = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unselect()
    {
        GetComponent<Renderer>().material = old;
    }

    void OnMouseDown()
    {
        GetComponent<Renderer>().material = Outline;
        GameObject.Find("Manager").GetComponent<Inventory>().select(name, this);
    }
}
