using System;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Menu : MonoBehaviour
{
    public Network Network;
    public Text Ip;
    public Text Port;
    public GameObject MenuObject;
    public GameObject LoadingObject;

    Loading loading;
    string ip = "";
    int port;


    bool connected = false;

    private void Start()
    {
        loading = LoadingObject.GetComponent<Loading>();
    }

    private void Update()
    {
        string s1;

        s1 = "" + Port.text;
        ip = Ip.text;
        try
        {
            port = int.Parse(s1);
        }
        catch
        {
        }

    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();

    }

    public void Join()
    {
        Debug.Log("Join " + ip + " port : " + port);
        MenuObject.SetActive(false);
        LoadingObject.SetActive(true);
        loading.Status = "Connexion";
        Network.Connect(ip, port);

    }

    public void Back()
    {
        MenuObject.SetActive(true);
        LoadingObject.SetActive(false);
    }

}
