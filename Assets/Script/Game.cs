using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Player
{
    public int[] inv;
    public int id;
    public string dir;
    public GameObject obj;
}

public struct Team
{
    public Color color;
    public string name;
};

public struct Egg
{
    public int id;
    public GameObject obj;
    public Team team;
};

public class Game : MonoBehaviour
{

    public Transform TeamTextTransform;
    public GameObject Endtext; 
    public GameObject TeamText;
    public GameObject IntroCanvas;
    public GameObject GameCanvas;
    public GameObject Escape;
    public GameObject Menu;
    public GameObject Loading;
    public GameObject[] PlayerPrefabs;
    public GameObject EggPrefabs;
    public Transform EggTransform;
    public Transform PlayerTransform;
    public Map Map;

    int frequency = 1;

    public List<Team> Teams;
    public List<Egg> Eggs;
    public List<Player> Players;

    private void Start()
    {
        Teams = new List<Team>();
        Players = new List<Player>();
        Eggs = new List<Egg>();
    }

    public void Close()
    {
        int i;
        Teams = new List<Team>();
        Players = new List<Player>();
        Eggs = new List<Egg>();

        GetComponent<AudioSource>().Stop();
        i = PlayerTransform.childCount;
        //Debug.Log(i);
        while (--i >= 0)
        {
            //Debug.Log(i);
            Destroy(PlayerTransform.GetChild(i).gameObject);
        }
        i = EggTransform.childCount;
        //Debug.Log(i);
        while (--i >= 0)
        {
            //Debug.Log(i);
            Destroy(EggTransform.GetChild(i).gameObject);
        }
        Map.delete();
    }
    public void Command(string[] arg)
    {
        if (arg[0] == "msz")
            msz(arg);
        else if (arg[0] == "bct")
            bct(arg);
        else if (arg[0] == "tna")
            tna(arg);
        else if (arg[0] == "pnw")
            pnw(arg);
        else if (arg[0] == "ppo")
            ppo(arg);
        else if (arg[0] == "plv")
            plv(arg);
        else if (arg[0] == "pin")
            pin(arg);
        else if (arg[0] == "pex")
            pex(arg);
        else if (arg[0] == "pbc")
            pbc(arg);
        else if (arg[0] == "pie")
            pie(arg);
        else if (arg[0] == "pfk")
            pfk(arg);
        else if (arg[0] == "pic")
            pic(arg);
        else if (arg[0] == "pdr")
            pdr(arg);
        else if (arg[0] == "pgt")
            pgt(arg);
        else if (arg[0] == "pdi")
            pdi(arg);
        else if (arg[0] == "enw")
            enw(arg);
        else if (arg[0] == "eht")
            eht(arg);
        else if (arg[0] == "ebo")
            ebo(arg);
        else if (arg[0] == "edi")
            edi(arg);
        else if (arg[0] == "sgt" || arg[0] == "sst")
            sgt(arg);
        else if (arg[0] == "seg")
            seg(arg);
    }


    void msz(string[] arg)
    {
        Map.generate(int.Parse(arg[1]), int.Parse(arg[2]));
        IntroCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        Escape.SetActive(true);
        GetComponent<AudioSource>().Play();

        /*
        if (arg.Length == 3)
        {
            GameManager.Mapx = Int32.Parse(arg[1]);
            GameManager.Mapy = Int32.Parse(arg[2]);
            GameManager.initMap();
        }*/
    }

    void bct(string[] arg)
    {
        int x, y;
        int[] inv;

        x = int.Parse(arg[1]);
        y = int.Parse(arg[2]);
        inv = new int[] {
            int.Parse(arg[3]),
            int.Parse(arg[4]),
            int.Parse(arg[5]),
            int.Parse(arg[6]),
            int.Parse(arg[7]),
            int.Parse(arg[8]),
            int.Parse(arg[9]),
        };

        Map.loadTile(x, y, inv);
        /*
        int x, y, i;

        if (arg.Length == 10)
        {
            i = -1;
            x = Int32.Parse(arg[1]);
            y = Int32.Parse(arg[2]);
            if (x >= 0 && x < GameManager.Mapx && y >= 0 && y < GameManager.Mapy)
                while (++i < 7)
                {
                    GameManager.Map[y][x].Inventory[i] = int.Parse(arg[i + 3]);
                }
            GameManager.load_tile(GameManager.Map[y][x]);
        }*/
    }

    void tna(string[] arg)
    {
        Team t;
        Color c;
        int i = UnityEngine.Random.Range(0, 2);


        if (i == 0)
            c = new Color(255, UnityEngine.Random.Range(0, 255), UnityEngine.Random.Range(0, 255));
        else if (i == 1)
            c = new Color(UnityEngine.Random.Range(0, 255), 255, UnityEngine.Random.Range(0, 255));
        else
            c = new Color(UnityEngine.Random.Range(0, 255), UnityEngine.Random.Range(0, 255), 255);
        t.color = c;
        t.name = arg[1];

        Teams.Add(t);
        /*GameObject go = Instantiate(TeamText, TeamTextTransform);
        Text text = go.GetComponent<Text>();

        Debug.Log(c);
        text.CrossFadeColor(c, 1, false, false) ;
        text.text = arg[1];
        */

        /*
        if (arg.Length == 2)
        {
            Team team;

            team.color.a = //new Color(UnityEngine.Random.Range(0f, 0.98f), UnityEngine.Random.Range(0f, 0.98f), UnityEngine.Random.Range(0f, 0.98f), 1);
            team.color.r = 0;
            team.color.g = 0;
            team.color.b = 0;
            while (team.color.r + team.color.g + team.color.b < 1.5)
            {
                team.color.r = UnityEngine.Random.Range(0f, 1);
                team.color.g = UnityEngine.Random.Range(0f, 1);
                team.color.b = UnityEngine.Random.Range(0f, 1);
            }
            team.name = arg[1];
            GameManager.Teams.Add(team);
        }*/
    }

    void pnw(string[] arg)
    {
        Player p = new Player();
        int i = -1;

        while (Teams[++i].name != arg[6]) ;
        p.id = int.Parse(arg[1]);
        p.dir = arg[4];
        //PlayerPrefabs.GetComponentInChildren<SpriteRenderer>().color = Teams[i].color;
        p.obj = Instantiate(PlayerPrefabs[i % PlayerPrefabs.Length], Map.tab[int.Parse(arg[3]), int.Parse(arg[2])].obj.transform.position + 0.8f * Vector3.up, Quaternion.Euler(0, (int.Parse(arg[4]) - 1) * 90, 0), PlayerTransform);
        p.obj.GetComponent<Character>().setLevel(int.Parse(arg[5]));
        p.obj.name = "Player " + arg[1];
        Players.Add(p);
        /*Debug.Log("Level " + arg[5]);
        try
        {
            //obj.transform.Find("Level " + arg[5]).gameObject.SetActive(true);
            obj.transform.Find("Levels").transform.Find("Level " + arg[5]).gameObject.SetActive(true);

        }
        catch (Exception e)
        {
            Debug.Log("dont find bro !");
        }*/
        //obj.name = "player " + arg[1];
        //obj.GetComponentInChildren<SpriteRenderer>()
        //while (Teams[++i].name != arg[6]) ;
        /*SpriteRenderer rend = obj.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        Material m = new Material(Shader.Find("Sprites/Default"));
        
        m.name = "Material " + arg[1];
        m.color = Teams[i].color;
        rend.s*/
        //rend.color = Teams[i].color;
        //rend.material.shader = Shader.Find("Specular");
        //rend.material.SetColor("_SpecColor", Color.red);
        //rend.material.shader = Shader.Find("_Color");
        //rend.material.SetColor("_Color", Teams[i].color);
        /*
        if (arg.Length == 7)
        {
            int i;
            Player p;
            Vector3 pos;

            p.id = Int32.Parse(arg[1]);
            p.x = Int32.Parse(arg[2]);
            p.y = Int32.Parse(arg[3]);
            p.dir = (Int32.Parse(arg[4]) - 1) * 90;
            p.lvl = Int32.Parse(arg[5]);
            p.inventory = new int[7];
            p.team = arg[6];
            p.state = "Stand By";

            pos = GameManager.Map[p.y][p.x].Cube.transform.position;
            pos.y = 0.6f;
            p.perso = Instantiate(GameManager.Persos[p.lvl - 1], pos, Quaternion.Euler(0, p.dir, 0), GameManager.Plist);
            Destroy(Instantiate(GameManager.Effects[0], p.perso.transform), 2);
            p.perso.GetComponent<Animator>().speed = GameManager.Frequency;
            //p.perso.GetComponent<Select>().GameManager = GameManager;
            GameManager.Players.Add(p);
            i = -1;
            while (GameManager.Teams[++i].name != p.team) ;
            p.perso.GetComponentInChildren<Renderer>().material.color = GameManager.Teams[i].color;
            GameManager.Sound[0].Play();
        }*/
    }

    void ppo(string[] arg)
    {
        // if (arg. == 5)
        //{
        Player p;
        Player n;
        Vector3 pos;
        int i;

        p.id = int.Parse(arg[1]);
        //p.x = Int32.Parse(arg[2]);
        //p.y = Int32.Parse(arg[3]);
        //p.dir = arg[4];
        //Debug.Log(arg[1] + " mouvement ");

        i = -1;
        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;
        Transform t = Players[i].obj.transform;
        //Transform t = GameObject.Find("Player " + int.Parse(arg[1])).transform;
        t.position = Map.tab[int.Parse(arg[3]), int.Parse(arg[2])].obj.transform.position + 0.8f * Vector3.up;
        t.rotation = Quaternion.Euler(0, (int.Parse(arg[4]) - 1) * 90, 0);
        /*if (Players[i].dir != p.dir)
        {
            Debug.Log("JE TOURRRRNNEEEEEEEE  !!!");
            Players[i].obj.GetComponent<Character>().rotate(int.Parse(arg[4]));
            //StartCoroutine(rotate(0.5f, Players[i].obj, (int.Parse(arg[4]) - 1) * 90));
            //n = GameManager.Players[i];
            //n.dir = p.dir;

        }
        /*      else if (GameManager.Players[i].x != p.x || GameManager.Players[i].y != p.y)
              {
                  if (Mathf.Abs(GameManager.Players[i].x - p.x) > 1 || Mathf.Abs(p.y - GameManager.Players[i].y) > 1)
                  {
                      p.lvl = GameManager.Players[i].lvl;
                      p.team = GameManager.Players[i].team;
                      p.perso = GameManager.Players[i].perso;
                      p.state = GameManager.Players[i].state;
                      p.inventory = GameManager.Players[i].inventory;
                      //p = GameManager.Players[i];
                      GameManager.Players[i] = p;
                      pos = GameManager.Map[p.y][p.x].Cube.transform.position;
                      pos.y = 0.6f;
                      StartCoroutine(tp(7 / GameManager.Frequency, p, pos));

                  }
                  else
                  {
                      p.lvl = GameManager.Players[i].lvl;
                      p.team = GameManager.Players[i].team;
                      p.perso = GameManager.Players[i].perso;
                      p.state = GameManager.Players[i].state;
                      p.inventory = GameManager.Players[i].inventory;
                      GameManager.Players[i] = p;
                      pos = GameManager.Map[p.y][p.x].Cube.transform.position;
                      pos.y = 0.6f;
                      // p.perso.transform.Translate((pos - p.perso.transform.position), 0);
                      StartCoroutine(forward(0.5f, p, pos));
                  }
              }*/
        //}
    }

    /*public IEnumerator tp(float time, Player p, Vector3 pos)
    {
        GameObject effect1;
        GameObject effect2;

        effect1 = Instantiate(GameManager.Effects[1], p.perso.transform);
        effect2 = Instantiate(GameManager.Effects[1], pos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        p.perso.transform.position = pos;
        Destroy(effect1);
        Destroy(effect2);
    }*/

  /*  IEnumerator rotate(float time, GameObject obj, float r)
    {
        float old = obj.transform.rotation.eulerAngles.y;
        float t;

        t = 0;
        while (t < time)
        {

            obj.transform.Rotate(new Vector3(0, (r - obj.transform.rotation.eulerAngles.y) * Time.deltaTime / time, 0));
            //tran.Translate(dist * Time.deltaTime / time, 0, 0);
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        //GameManager.Players[i] = p;
    }*/

    /*IEnumerator forward(float time, Player p, Vector3 pos)
    {
        float t;
        Vector3 old = p.perso.transform.position;

        p.perso.GetComponent<Animator>().SetBool("Walk", true);
        t = 0;
        while (t < time)
        {
            p.perso.transform.Translate((pos - old) * Time.deltaTime / time, 0);
            //tran.Translate(dist * Time.deltaTime / time, 0, 0);
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        p.perso.GetComponent<Animator>().SetBool("Walk", false);
        p.perso.transform.position = pos;
    }*/

    void plv(string[] arg)
    {
        int i = -1;

        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;
        Players[i].obj.GetComponent<Character>().up(int.Parse(arg[2]));
       // GameObject.Find("Player " + arg[1]).GetComponent<Character>().up(int.Parse(arg[2]));
        /*
        if (arg.Length == 3)
        {
            int id;
            int i;
            int lvl;
            Vector3 pos;
            Player p;

            id = Int32.Parse(arg[1]);
            lvl = Int32.Parse(arg[2]);
            i = -1;
            while (++i < GameManager.Players.Count && GameManager.Players[i].id != id) ;
            if (i == GameManager.Players.Count)
                return;
            p = GameManager.Players[i];
            //Destroy(p.perso);
            p.id = id;
            p.lvl = lvl;
            pos = GameManager.Map[p.y][p.x].Cube.transform.position;
            pos.y = 0.6f;
            //Destroy(Instantiate(GameManager.Effects[2], p.perso.transform), 2);
            //p.perso = Instantiate(GameManager.Persos[p.lvl - 1], pos, Quaternion.Euler(0, p.dir, 0), GameManager.Plist);
            /*i = -1;
            while (GameManager.Teams[++i].name != p.team) ;
            p.perso.GetComponentInChildren<Renderer>().material.color = GameManager.Teams[i].color;/
    }*/
    }

    void pin(string[] arg)
    {
        int[] tab = new int[] {
            int.Parse(arg[3]),
            int.Parse(arg[4]),
            int.Parse(arg[5]),
            int.Parse(arg[6]),
            int.Parse(arg[7]),
            int.Parse(arg[8]),
            int.Parse(arg[9]),
        };

        int i = -1;
        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;
        Players[i].obj.GetComponent<Character>().setInv(tab);
        //GameObject.Find("Player " + arg[1]).GetComponent<Character>().setInv(tab);

        /*
        if (arg.Length == 10)
        {
            int i;
            int j;
            int id;

            i = -1;
            id = Int32.Parse(arg[1]);
            while (++i < GameManager.Players.Count && GameManager.Players[i].id != id) ;
            if (i == GameManager.Players.Count)
                return;
            j = -1;
            while (++j < 7)
            {
                GameManager.Players[i].inventory[j] = int.Parse(arg[j + 4]);
            }
        }*/
    }

    void pex(string[] arg)
    {
        int i = -1;
        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;
        Players[i].obj.GetComponent<Character>().eject();
        /*Debug.Log("Player " + arg[1]);
        GameObject g = GameObject.Find("Player " + arg[1]);
        Debug.Log(g);
        *///.GetComponent<Character>();//.eject();

        /*
        if (arg.Length == 2)
        {
            int i;
            int id;

            id = Int32.Parse(arg[1]);
            i = -1;
            while (GameManager.Players[++i].id != id) ;
            GameManager.Players[i].perso.GetComponent<Animator>().SetTrigger("Eject");
            Destroy(Instantiate(GameManager.Effects[3], GameManager.Players[i].perso.transform), 2);
        }*/
    }

    void pbc(string[] arg)
    {
        int i = -1;
        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;
        Players[i].obj.GetComponent<Character>().talk(arg[2]);
        //GameObject.Find("Player " + arg[1]).GetComponent<Character>().talk(arg[2]);

        /*
        if (arg.Length == 2)
        {
            int i;
            int id;
            string msg;

            id = Int32.Parse(arg[1]);
            msg = arg[2];
            i = -1;
            while (GameManager.Players[++i].id != id) ;
            GameManager.Players[i].perso.GetComponent<Animator>().SetTrigger("Name");
        }*/
    }

    void pic(string[] arg)
    {
        int i = -1;
        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;
        Players[i].obj.GetComponent<Character>().incant();
        //GameObject.Find("Player " + arg[1]).GetComponent<Character>().incant();

        /*
        if (arg.Length > 4)
        {
            int i;
            int j;
            int id;
            Player p;

            i = 3;
            id = Int32.Parse(arg[4]);
            while (++i < arg.Length)
            {
                j = -1;
                while (GameManager.Players[++j].id != id) ;
                p = GameManager.Players[j];
                Destroy(Instantiate(GameManager.Effects[4], p.perso.transform.position, p.perso.transform.rotation), 300 / GameManager.Frequency);
                StartCoroutine(incant(300 / GameManager.Frequency, p, p.x, p.y));
            }
        }*/
    }

    /*public IEnumerator incant(float time, Player p, int x, int y)
    {/*
        float t;
        Vector3 old = p.perso.transform.position;

        p.perso.GetComponent<Animator>().SetBool("incant", true);
        t = 0;
        while (t < time)
        {
            if (p.perso != null && p.perso.GetComponent<Animator>().GetBool("Walk"))
                p.perso.GetComponent<Animator>().SetBool("incant", false);
            if (p.perso != null && p.x == x && p.y == y)
                p.perso.GetComponent<Animator>().SetBool("incant", true);
            //tran.Translate(dist * Time.deltaTime / time, 0, 0);
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        p.perso.GetComponent<Animator>().SetBool("Walk", false);
    }*/

    void pie(string[] arg)
    {
        int i = -1;
        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;
        Players[i].obj.GetComponent<Character>().incantEnd();
        //GameObject.Find("Player " + arg[1]).GetComponent<Character>().incantEnd();

        /*
        if (arg.Length == 2)
        {
            if (arg[3] == "1")
                GameManager.Sound[3].Play();
            else if (arg[3] == "1")
                GameManager.Sound[4].Play();
        }*/
    }

    void pfk(string[] arg)
    {
        int i = -1;
        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;

        Players[i].obj.GetComponent<Character>().laying();
        /*
        if (arg.Length == 2)
        {
            int i;
            int id;

            id = Int32.Parse(arg[1]);
            i = -1;
            while (GameManager.Players[++i].id != id) ;
            StartCoroutine(laying(42 / GameManager.Frequency, GameManager.Players[i]));
        }*/
    }

    /*public IEnumerator laying(float time, Player p)
    {/*
        Destroy(Instantiate(GameManager.Effects[5], p.perso.transform.position, p.perso.transform.rotation), time);
        p.perso.GetComponent<Animator>().SetBool("Magic", true);
        yield return new WaitForSeconds(time);
        if (p.perso != null)
            p.perso.GetComponent<Animator>().SetBool("Magic", false);
    }*/


    void pdr(string[] arg)
    {
        int i = -1;
        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;
        Players[i].obj.GetComponent<Character>().collect();
        //GameObject.Find("Player " + arg[1]).GetComponent<Character>().collect();
        /*
        if (arg.Length == 3)
        {
            int i;
            int j;
            int id;

            id = Int32.Parse(arg[1]);

            i = -1;
            while (GameManager.Players[++i].id != id) ;
            j = Int32.Parse(arg[2]);
            GameManager.Players[i].inventory[j] = GameManager.Players[i].inventory[j] - 1;
            GameManager.Players[i].perso.GetComponent<Animator>().SetTrigger("Take");
        }
        */
    }

    void pgt(string[] arg)
    {
        int i = -1;
        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
        if (i == Players.Count)
            return;
        Players[i].obj.GetComponent<Character>().collect();
        //GameObject.Find("Player " + int.Parse(arg[1])).GetComponent<Character>().collect();

        /*
        if (arg.Length == 3)
        {
            int i;
            int j;
            int id;

            id = Int32.Parse(arg[1]);

            i = -1;
            while (GameManager.Players[++i].id != id) ;
            j = Int32.Parse(arg[2]);
            GameManager.Players[i].inventory[j] = GameManager.Players[i].inventory[j] + 1;
            GameManager.Players[i].perso.GetComponent<Animator>().SetTrigger("Take");
        }*/
    }


    void pdi(string[] arg)
    {
        int i = -1;
        //Debug.Log(Players);
        //Debug.Log(int.Parse(arg[1]));

        while (++i < Players.Count && Players[i].id != int.Parse(arg[1])) ;
           // Debug.Log(Players[i].id);
        if (i == Players.Count)
        {
            Debug.Log("Pas trouver");
            return;
        }
        Players[i].obj.GetComponent<Character>().die();
        //GameObject.Find("Player " + arg[1]).GetComponent<Character>().die();

        /*
        if (arg.Length == 2)
        {
            int i;
            int id;

            id = Int32.Parse(arg[1]);

            i = -1;
            while (GameManager.Players[++i].id != id) ;
            GameManager.Players[i].perso.GetComponent<Animator>().SetTrigger("Dead");
            StartCoroutine(dead(4 / GameManager.Frequency, GameManager.Players[i]));
        }*/
    }

    /*public IEnumerator dead(float time, Player p)
    {
        yield return new WaitForSeconds(time);
        if (p.perso != null)
        {
            Destroy(Instantiate(GameManager.Effects[6], p.perso.transform.position, p.perso.transform.rotation), 2);
            Destroy(p.perso);
        }
        GameManager.Players.Remove(p);
        GameManager.Sound[1].Play();
    }*/

    void enw(string[] arg)
    {
        Egg e = new Egg();
        int i = -1;

        while (++i < Players.Count && Players[i].id != int.Parse(arg[2])) ;
        Players[i].obj.GetComponent<Character>().layingend();
        e.id = int.Parse(arg[1]);
        //PlayerPrefabs.GetComponentInChildren<SpriteRenderer>().color = Teams[i].color;
        e.obj = Instantiate(EggPrefabs, Map.tab[int.Parse(arg[4]), int.Parse(arg[3])].obj.transform.position + 0.8f * Vector3.up, Quaternion.identity, EggTransform);
        Eggs.Add(e);
        
    }

    void eht(string[] arg)
    {
        int i = -1;

        while (++i < Eggs.Count && Eggs[i].id != int.Parse(arg[1])) ;
        Eggs[i].obj.transform.localScale *= 2;
        /*
        if (arg.Length == 2)
        {
        }*/
    }

    void ebo(string[] arg)
    {
        int i = -1;

        while (++i < Eggs.Count && Eggs[i].id != int.Parse(arg[1]));
        Egg e = Eggs[i];
        Eggs.RemoveAt(i);
        Destroy(e.obj);
        /*
        Player p = new Player();
        int i = -1;

        //while (Teams[++i].name != arg[6]) ;
        p.id = int.Parse(arg[1]);
        //PlayerPrefabs.GetComponentInChildren<SpriteRenderer>().color = Teams[i].color;
        p.obj = Instantiate(PlayerPrefabs, Map.tab[int.Parse(arg[3]), int.Parse(arg[2])].obj.transform.position + 0.8f * Vector3.up, Quaternion.Euler(0, (int.Parse(arg[4]) - 1) * 90, 0), PlayerTransform);
        p.obj.GetComponent<Character>().setLevel(int.Parse(arg[5]));
        p.obj.name = "Player " + arg[1];
        Players.Add(p);
        while (++i < Eggs.Count && Eggs[i].id != int.Parse(arg[1])) ;*/

        /*
        if (arg.Length == 2)
        {
            int i;
            int id;

            id = Int32.Parse(arg[1]);

            i = -1;
            while (GameManager.Eggs[++i].id != id) ;
            Destroy(GameManager.Eggs[i].perso);
            GameManager.Eggs.Remove(GameManager.Eggs[i]);
        }*/
    }

    void edi(string[] arg)
    {
        int i = -1;

        while (++i < Eggs.Count && Eggs[i].id != int.Parse(arg[1])) ;
        Egg e = Eggs[i];
        Eggs.RemoveAt(i);
        Destroy(e.obj);
        /*
        if (arg.Length == 2)
        {
        }*/
    }

    void sgt(string[] arg)
    {
        frequency = int.Parse(arg[1]);
        /*
        int i;

        if (arg.Length == 2)
        {

            GameManager.Frequency = Int32.Parse(arg[1]);
            i = -1;
            while (++i < GameManager.Players.Count)
            {
                GameManager.Players[i].perso.GetComponent<Animator>().speed = GameManager.Frequency;
            }
        }*/
    }

    void seg(string[] arg)
    {
        Debug.Log("khaalaaaasss");
        Endtext.SetActive(true);
        Endtext.GetComponentInChildren<Text>().text = "La team " + arg[1] + " a gagné !";
        /*
        if (arg.Length == 2)
        {
            GameManager.Sound[4].Play();
            StartCoroutine(go(1));
        }*/
    }
    /*
    public IEnumerator go(float time)
    {
        /*
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("GameOver");
    }*/


}
