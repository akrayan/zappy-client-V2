using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Map Map;
    public Text[] Tab;
    Select old = null;
    Character oldc = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void selectCharacter(Character cha)
    {
        int i = -1;

        if (old != null)
        {
            old.unselect();
            old = null;
        }
        if (oldc != null)
        {
            oldc.unselect();
        }
        oldc = cha;
        while (++i < 7)
        {
            Tab[i].text = "" + cha.inv[i];
        }

    }

    public void select(string name, Select select)
    {
        int i = -1, x, y;
        char[] separator = { ' ' };
        string[] tab = name.Split(separator);

        if (old != null)
            old.unselect();
        if (oldc != null)
        {
            oldc.unselect();
            oldc = null;
        }
        old = select;
        if (tab[0] == "cube")
        {
            x = int.Parse(tab[1]);
            y = int.Parse(tab[2]);
            while (++i < 7)
            {
                Tab[i].text = "" + Map.tab[y, x].inv[i];
            }
        }
    }
}
