using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollidingWithBarrier : MonoBehaviour
{
    public static bool barrierCollision;
    public static bool isInWBarrier;
    public static bool isInEBarrier;
    public static bool isInNBarrier;
    public static bool isInSBarrier;
    public static bool touchBase;

    void Start()
    {
        touchBase = false;
    }

    //void bCol()
    //{
    //    Debug.Log(isInWBarrier);
    //}

    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "NBarrier")
            {
                barrierCollision = true;
                isInNBarrier = true;
            }
            if (other.gameObject.tag == "WBarrier")
            {
                barrierCollision = true;
                isInWBarrier = true;
            }
            if (other.gameObject.tag == "EBarrier")
            {
                barrierCollision = true;
                isInEBarrier = true;
            }
            if (other.gameObject.tag == "SBarrier")
            {
                barrierCollision = true;
                isInSBarrier = true;
            }

            //respawn a new piece;
            if (other.gameObject.tag == "Base")
            {
                touchBase = true;
                Debug.Log($"InstantiatedObject is touching the base{BlockCollidingWithBarrier.isInEBarrier}");
            }

            //touchBase = false;
            barrierCollision = false;

        }


    void Update()
    {
        //barrierCollision = false;
        //Debug.Log(barrierCollision);
    }

}
