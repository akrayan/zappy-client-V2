using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float RotationSpeed = 2.5f;
    public float MoveSpeed = 2.5f;
    public GameObject[] Levels;
    Animator animator;
    Quaternion rot;
    public int[] inv;
    Material old;
    public Material Outlined;
    public Transform Body;
    bool isSelect = false;
    // Start is called before the first frame update
    void Start()
    {
        old = Body.GetComponent<Renderer>().material;
        animator = GetComponent<Animator>();
        inv = new int[]
            {
            0,
            0,
            0,
            0,
            0,
            0,
            0,
        }; 
    }

    public void unselect()
    {
        isSelect = false;
        Body.GetComponent<Renderer>().material = old;

    }

    private void OnMouseDown()
    {
        isSelect = true;
        Body.GetComponent<Renderer>().material = Outlined;
        GameObject.Find("Manager").GetComponent<Inventory>().selectCharacter(this);
    }

    /*    Vector3 getTarget(int dir)
        {
            Vector3 res = dir == 1 ? Vector3.forward :
                (dir == 2) ? Vector3.right :
                (dir == 3) ? Vector3.back :
                Vector3.left;
            return res;
        }

        public void rotate(int dir)
        {

            Vector3 ndir = getTarget(dir);
            //ndir.y = 0; // keep the direction strictly horizontal
            Quaternion rot = Quaternion.LookRotation(ndir);
            StartCoroutine(rotateAnim(rot));
            // slerp to the desired rotation over time
        }

        IEnumerator rotateAnim(Quaternion rot)
        {
            while (transform.rotation != rot)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime / );
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        */
    public void setLevel(int lvl)
    {
        int i = -1;

        while (++i < 8)
        {
            Levels[i].SetActive(lvl - 1 == i);
        }
    }

    public void setInv(int[] tab)
    {
        inv = tab;
        if (isSelect)
            GameObject.Find("Manager").GetComponent<Inventory>().selectCharacter(this);
    }

    public void collect()
    {
        Debug.Log("cooooolect");
        animator.SetTrigger("Collecto");
    }
    public void egg()
    {
        animator.SetTrigger("egg");

    }
    public void die()
    {
        Debug.Log("noooooooo");
        animator.SetTrigger("die");
        Destroy(gameObject, 3);

    }
    public void up(int lvl)
    {
        animator.SetTrigger("up");
        setLevel(lvl);
    }

    public void layingend()
    {
        animator.SetBool("laying", false);

    }
    public void laying()
    {
        animator.SetBool("laying", true);

    }

    public void eject()
    {
        animator.SetTrigger("eject");

    }

    public void incant()
    {
        animator.SetBool("incantation", true);

    }

    public void incantEnd()
    {
        animator.SetBool("incantation", false);

    }

    public void talk(string str)
    {
        animator.SetTrigger("talk");

    }



    float t = 0;
    bool b = true;
    // Update is called once per frame
    void Update()
    {
        //Quaternion.Slerp(transform.rotation, rot, Time.deltaTime / );
        /*    t += Time.deltaTime;
            if (t > 2 && b)
            {
                collect();
                b = !b;

            }*/
    }
}
