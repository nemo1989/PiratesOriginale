﻿using UnityEngine;
using System.Collections;

public class LightfollowPath : MonoBehaviour {
    public GameObject[] node;
    public GameController controller;
    int numberOfNodes;
   public int speed =3;
    bool reachedArrayLenth = false;
    int i = 0;
    public float delayTime;
    float time;
    // Use this for initialization
    void Start()
    {

        numberOfNodes = node.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfNodes > 0)
        {
            if (!controller.win && !controller.gameOver)
            {
                transform.position = Vector3.MoveTowards(transform.position, node[i].transform.position, speed * Time.deltaTime);
                if (transform.position == node[i].transform.position && !reachedArrayLenth)
                {
                    
                    if (i < numberOfNodes - 1 )
                    {
                        time += Time.deltaTime;
                        if (time > delayTime)
                        {
                            i++;
                            time = 0;
                        }

                    }
                    else
                    {
                        //reachedArrayLenth = true;
                        i = 0;
                    }

                }
            }
            /*if(transform.position == node[i].transform.position && reachedArrayLenth)
            {
                i--;
                if(i==0)
                {
                        reachedArrayLenth = false;
                    }
            }*/
        }

    }
}

