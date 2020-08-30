using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject Camera;
    public GameObject[] Cubes;
    public GameObject[] Items;
    public float Space = 0;

    public Tile[,] tab;

    public void delete()
    {
        int i;
        i = transform.childCount;
        //Debug.Log(i);
        while (--i >= 0)
        {
            //Debug.Log(i);

            Destroy(transform.GetChild(i).gameObject);
        }
        //while (transform.childCount != 0)
            //Destroy(transform.GetChild(transform.childCount - 1));
    }

    public void generate(int width, int height)
    {
        int i, j = -1;
        Vector3 pos = new Vector3(0, 0, 0);
        Vector3 pcam = new Vector3((width + Space * width) / 2, 5, -(3 * height * width) / 100 - (height + Space * height) );
        Camera.transform.position = pcam;

        tab = new Tile[height, width];

        while (++j < height)
        {
            i = -1;
            while (++i < width)
            {
                pos.x = i * (1 + Space);
                pos.z = -j * (1 + Space);
                tab[j, i].inv = new int[7];
                tab[j, i].obj = Instantiate(Cubes[(i + j) % Cubes.Length], pos, Quaternion.identity, transform);
                tab[j, i].obj.name = "cube " + i + " " + j;
                //Map[j][i].Cube.GetComponent<Select>().GameManager = GetComponent<Game>();
            }
        }
    }

    public void loadTile(int x, int y, int[] inv)
    {
        int i, j;
        Vector3 pos;
        Vector3 pos2;

        if (tab.Length < x * y)
            return;
        Transform Invt = tab[y, x].obj.transform.Find("Inv");

        tab[y, x].inv = inv;
        i = Invt.childCount;
        while (--i >= 0)
            Destroy(Invt.GetChild(i).gameObject);
        pos = Invt.position;
        pos.y = 0.55f;
        i = -1;
        while (++i < 7)
        {

            j = -1;
            while (++j < tab[y, x].inv[i])
            {
                pos2 = pos;
                pos2.x = Random.Range(pos.x - 0.5f, pos.x + 0.5f);
                pos2.z = Random.Range(pos.z - 0.5f, pos.z + 0.5f);
                Instantiate(Items[i], pos2, Quaternion.identity, Invt);
            }
        }
    }
    /*
    public void loadTile()

    public void initMap()
    {
        Vector3 pcam;
        Vector3 pos = new Vector3(0, 0, 0);
        int i;
        int j;

        j = -1;
        Map = new Tile[Mapy][];
        while (++j < Mapy)
        {
            Map[j] = new Tile[Mapx];
            i = -1;
            while (++i < Mapx)
            {
                pos.x = i * (1 + Space);
                pos.z = j * (1 + Space);
                Map[j][i].Inventory = new int[7];
                Map[j][i].Cube = Instantiate(Cubes[(i + j) % Cubes.Length], pos, Quaternion.identity, Map_t);
                Map[j][i].Cube.GetComponent<Select>().GameManager = GetComponent<Game>();
            }
            pcam.x = Mapx / 2;
            pcam.z = (Mapy / 2) - 5;
            pcam.y = 3;
            Camera.transform.position = pcam;
        }
    }

    public void load_tile(Tile t)
    {
        int i, j;
        Vector3 pos;
        Vector3 pos2;

        i = t.Cube.transform.childCount;
        while (--i >= 0)
            Destroy(t.Cube.transform.GetChild(i).gameObject);
        pos = t.Cube.transform.position;
        pos.y = 0.55f;
        i = -1;
        while (++i < 7)
        {

            j = -1;
            while (++j < t.Inventory[i])
            {
                pos2 = pos;
                pos2.x = Random.Range(pos.x - 0.5f, pos.x + 0.5f);
                pos2.z = Random.Range(pos.z - 0.5f, pos.z + 0.5f);
                Instantiate(Items[i], pos2, Quaternion.identity, t.Cube.transform);
            }
        }
    }*/
}

public struct Tile
{
    public int[] inv;
    public GameObject obj;
}