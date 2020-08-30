using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public string Status = "Connexion";
    public GameObject Back;
    public GameObject Connexion;
    public GameObject Generation;
    public GameObject Error;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Status)
        {
            case "Connexion" :
                Back.SetActive(false);
                Connexion.SetActive(true);
                Generation.SetActive(false);
                Error.SetActive(false);
                break;
            case "Generation":
                Back.SetActive(false);
                Connexion.SetActive(false);
                Generation.SetActive(true);
                Error.SetActive(false);
                break;
            case "Error":
                Back.SetActive(true);
                Connexion.SetActive(false);
                Generation.SetActive(false);
                Error.SetActive(true);
                break;
        }
        
    }
}
