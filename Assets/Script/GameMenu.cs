using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject Option;
    public Game Game;
    public Network Network;
    public GameObject Menu;
    public GameObject MenuMenu;
    public GameObject MenuLoading;
    public GameObject EndImage;
    public GameObject Inv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Option.SetActive(!Option.activeSelf);
        }
    }

    public void Back()
    {
        Option.SetActive(false);
    }

    public void Quit()
    {
        Network.Disconnect();
        Game.Close();
        Option.SetActive(false);
        Menu.SetActive(true);
        MenuMenu.SetActive(true);
        MenuLoading.SetActive(false);
        gameObject.SetActive(false);
        EndImage.SetActive(false);
        Inv.SetActive(false);
    }
}
