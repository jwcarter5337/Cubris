using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using Cinemachine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class BlockSpawner : MonoBehaviour
{
    public GameObject instantiatedObject;
    public List<GameObject> newPlacedBlocks;
    public GameObject[] BlockList;
    public int randomIndex;
    public GameObject spawner;
    public static Vector3 positionOfSpawner;
    public static float _time;
    private int i;
    private int j;
    private int k;
    public float deadZone;
    private bool horizontalWasInDeadZone;
    private bool verticalWasInDeadZone;

    private GameObject newRandomObject()
    {
        randomIndex = Random.Range(0, BlockList.Length);
        return Instantiate(BlockList[randomIndex], positionOfSpawner, Quaternion.identity) as GameObject;
    }


        

    void Start()
    {

        _time = 0f;

        positionOfSpawner = spawner.transform.position;

        instantiatedObject = newRandomObject();


        //instantiatedObject.transform.position = Speed * Time.deltaTime;

        j = 12;

        i = -4;

        k = -3;



        //wasInDeadZone = true;

    }

    void Update()
    {

        //Debug.Log(instantiatedObject.transform.position);
        
        _time += Time.deltaTime;
        instantiatedObject.transform.position = GridCoordinatesToPosition(i, j, k, new Vector3(6.8f, 1.125f, 6.8f));
        //NewBlocks.newInstantiatedObject.transform.position = NewBlocks.NewGridCoordinatesToPosition(i,j,k, new Vector3(6.8f, 1.125f, 6.8f));


        if (j > 0)
        {
            if (_time > 1f)
            {
                j--;
                _time = 0f;
            }
        }

        //if (BlockCollidingWithBarrier.touchBase == true)
        //{
        //    newInstantiatedObject = Instantiate(BlockList[randomIndex], positionOfSpawner, Quaternion.identity) as GameObject;
        //    Instantiate (newInstantiatedObject, positionOfSpawner, Quaternion.identity);
        //    //transfer control to new instantiated object

        //}

        {
            var rightHeld = Input.GetAxis("Horizontal") > deadZone;
            var leftHeld = Input.GetAxis("Horizontal") < -deadZone;
            var upHeld = (Input.GetAxis("Vertical") > deadZone);
            var downHeld = (Input.GetAxis("Vertical") < -deadZone);

            var rightOnePush = rightHeld && horizontalWasInDeadZone;
            var leftOnePush = leftHeld && horizontalWasInDeadZone;
            var upOnePush = upHeld && verticalWasInDeadZone;
            var downOnePush = downHeld && verticalWasInDeadZone;
            //var bCollision = BlockCollidingWithBarrier.barrierCollision;

            if (rightOnePush && BlockCollidingWithBarrier.isInEBarrier == false)
            {
                horizontalWasInDeadZone = false;
                i = i + 1;
            }
            //else if (rightHeld && _time2 > .25f)
            //{
            //    horizontalWasInDeadZone = false;
            //    i = i + 1;
            //    _time2 = 0f;
            //}

            if (leftOnePush && BlockCollidingWithBarrier.isInWBarrier == false)
            {
                horizontalWasInDeadZone = false;
                i = i - 1;
            }

            if (upOnePush && BlockCollidingWithBarrier.isInNBarrier == false)
            {
                verticalWasInDeadZone = false;
                k = k + 1;
            }

            if (downOnePush && BlockCollidingWithBarrier.isInSBarrier == false)
            {
                verticalWasInDeadZone = false;
                k = k - 1;
            }

                //if (rightHeld && !horizontalWasInDeadZone && _time2 > .25f)
                //{
                //    i = i + 1;
                //    _time2 = 0f;
                //}

            if (!rightHeld && !leftHeld)
            {
                horizontalWasInDeadZone = true;
            }

            if (!upHeld && !downHeld)
            {
                verticalWasInDeadZone = true;
            }

            if (rightHeld == true)
            {
                //Debug.Log($"this is in east barrier {BlockCollidingWithBarrier.isInEBarrier}");
                BlockCollidingWithBarrier.isInWBarrier = false;
            }

            if (leftHeld == true)
            {
                //Debug.Log($"this is in west barrier {BlockCollidingWithBarrier.isInWBarrier}");
                BlockCollidingWithBarrier.isInEBarrier = false;
            }

            if (upHeld == true)
            {
                BlockCollidingWithBarrier.isInSBarrier = false;
            }

            if (downHeld == true)
            {
                BlockCollidingWithBarrier.isInNBarrier = false;
            }
            //_time2 = 0;



            if (BlockCollidingWithBarrier.touchBase == true)
            {
                newPlacedBlocks.Add(instantiatedObject);

            }
        }
    }


    public static Vector3 GridCoordinatesToPosition(int i, int j, int k, Vector3 origin, float gridSize = 2.25f)
        {
            var x = origin.x + i * gridSize;
            var y = origin.y + j * gridSize;
            var z = origin.z + k * gridSize;

            return new Vector3(x, y, z);
        }

    


        //Spawn an object for debugging
        //if (Input.GetKeyDown("w"))
        //{
        //    Instantiate(instantiatedObject,positionOfSpawner, Quaternion.identity);
        //}
    }
