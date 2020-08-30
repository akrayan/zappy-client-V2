using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Network : MonoBehaviour
{
    public Game Game;
    public Loading loading;
    string ip = "";
    int port;

    private NetworkStream stream;
    private char[] sspace = { ' ' };
    private char[] sline = { '\n' };

    bool connected = false;
    // Start is called before the first frame update


    private TcpClient socketConnection;
    private Thread clientReceiveThread;

    public void Disconnect()
    {
        connected = false;
        ii = 0;
        //stream.Close();
        //socketConnection.Close();
        
    }

    public void Connect(string ip, int port)
    {
        this.ip = ip;
        this.port = port;

        try
        {
            clientReceiveThread = new Thread(new ThreadStart(Connection));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }

        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
            loading.Status = "Error";

        }
    }

    private void Connection()
    {
        try
        {
            Thread.Sleep(1000);
            connected = true;
            //socketConnection = new TcpClient(ip, port);
            //ConnectionEnd();
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException + "\n" + socketException.SocketErrorCode + "\n" + socketException.HelpLink);
            loading.Status = "Error";

        }
    }

    void ConnectionEnd()
    {
        if (socketConnection.Connected)
        {

            stream = socketConnection.GetStream();
            byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes("GRAPHIC\n");
            stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
            connected = true;
        }
        else
        {
            loading.Status = "Error";
        }
    }
    // Update is called once per frame
    float t = 1;
    int ii = 0;
    void Update()
    {
        if (connected)
        {
            t += Time.deltaTime;
            if (t > 0.5f && ii < Cmd.Length)
            {
                string[] arg;

                Debug.Log(Cmd[ii]);
                arg = Cmd[ii].Split(sspace);
                Game.Command(arg);
                //if (arg[0] == "ppo")
                    t = 0;
                ii++;
            }
            /*if (stream.DataAvailable)
            {
                string s;
                string[] arg;
                string[] cmd;
                byte[] by = new byte[50000];
                int i = -1; ;

                stream.Read(by, 0, 50000);
                s = System.Text.Encoding.Default.GetString(by);
                Debug.Log(s);
                cmd = s.Split(sline);
                while (++i < cmd.Length - 1)
                {
                    arg = cmd[i].Split(sspace);
                    Game.Command(arg);
                }
            }*/

        }

    }

    string[] Cmd = new string[] {
        "msz 10 10\n msz\n map size",
        "bct 0 3 1 4 7 2 7 1 0\n bct X Y\n content of a tile",
        "bct 4 5 1 4 5 2 0 1 0\n bct X Y\n content of a tile",
        "bct 5 5 0 0 0 2 2 1 0\n bct X Y\n content of a tile",
        "bct 1 9 1 4 1 2 1 1 5\n bct X Y\n content of a tile",
        "bct 7 7 1 0 4 0 0 1 0\n bct X Y\n content of a tile",
        "bct 5 1 1 4 5 2 7 1 3\n bct X Y\n content of a tile",
        "tna bleu\n * nbr_teams tna\n name of all the teams",
        "tna red\n * nbr_teams tna\n name of all the teams",
        "tna green\n * nbr_teams tna\n name of all the teams",
        "pnw 0 0 3 1 3 red\n connection of a new player",
        "pnw 3 1 3 4 2 red\n connection of a new player",
        "pnw 5 5 5 3 5 red\n connection of a new player",
        "pnw 6 8 9 2 4 red\n connection of a new player",
        "pnw 1 8 8 2 6 bleu\n connection of a new player",
        "pnw 2 7 7 2 7 bleu\n connection of a new player",
        "pnw 8 6 6 2 8 bleu\n connection of a new player",
        "pnw 10 4 4 2 1 bleu\n connection of a new player",
        "pnw 4 7 9 2 1 green\n connection of a new player",
        "pnw 7 6 9 2 1 green\n connection of a new player",
        "pnw 9 5 9 2 1 green\n connection of a new player",
        "pnw 11 4 9 2 1 green\n connection of a new player",
        "ppo 0 0 4 1\n ppo #n\n player’s position",
        "ppo 11 4 9 1\n ppo #n\n player’s position",
        "ppo 11 4 9 4\n ppo #n\n player’s position",
        "ppo 11 4 9 3\n ppo #n\n player’s position",
        "ppo 11 4 9 4\n ppo #n\n player’s position",
        "ppo 9 5 9 3\n ppo #n\n player’s position",
        "ppo 9 5 0 3\n ppo #n\n player’s position",
        "plv 6 2\n plv #n\n player’s level",
        "pin 0 0 4 1 2 3 3 4 5 6\n pin #n\n player’s inventory",
        "pex 3\n explusion",
        "pbc 7 Puuuuuute\n broadcast",
        "pic 8 8 1 1",
        "pfk 2\n egg laying by the player",
        "pdr 10 2\n resource dropping",
        "pgt 5 4\n resource collecting",
        "pie 8 8 0\n end of an incantation",
        "pdi 8\n death of a player",
        "enw 0 1 9 1\n an egg was laid by a player",
        "enw 1 2 7 7\n an egg was laid by a player",
        "eht 0\n egg hatching",
        "ebo 0\n player connection for an egg",
        "pnw 12 9 1 1 1 bleu\n connection of a new player",
        "edi 1\n death of an hatched egg",
        "sgt 3\n sgt\n time unit request",
        "sst 3\n sst T\n time unit modification",
        "seg red\n end of game",
        "smg M\n message from the server",
        "suc\n unknown command",
        "sbp\n" };
}
