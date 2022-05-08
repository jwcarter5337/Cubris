using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class NewBlocks : MonoBehaviour
//{
//    public static GameObject newInstantiatedObject;
//    public GameObject[] newBlockList;
//    private int newRandomIndex;
//    private int i2;
//    private int j2;
//    private int k2;


//    // Start is called before the first frame update
//    void Start()
//    {
//        j2 = 12;

//        i2 = -4;

//        k2 = -3;

//        newRandomIndex = Random.Range(0, newBlockList.Length);
//    }
//     public static Vector3 NewGridCoordinatesToPosition(int i2, int j2, int k2, Vector3 origin, float gridSize = 2.25f)
//    {
//        var x = origin.x + i2 * gridSize;
//        var y = origin.y + j2 * gridSize;
//        var z = origin.z + k2 * gridSize;

//        return new Vector3(x, y, z);
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if (BlockCollidingWithBarrier.touchBase == true)
//        {
//            newInstantiatedObject = Instantiate(newBlockList[newRandomIndex], BlockSpawner.positionOfSpawner, Quaternion.identity) as GameObject;
//            //Instantiate(newInstantiatedObject, positionOfSpawner, Quaternion.identity);
//            //transfer control to new instantiated object
//            newInstantiatedObject.transform.position = NewBlocks.NewGridCoordinatesToPosition(i2, j2, k2, new Vector3(6.8f, 1.125f, 6.8f));
//        }
//        if (j2 > 0)
//        {
//            if (BlockSpawner._time > 1f)
//            {
//                j2--;
//                BlockSpawner._time = 0f;
//            }
//        }

//    }
   
//}
