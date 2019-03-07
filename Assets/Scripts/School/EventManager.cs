using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// hw/ implement a cube(masterCube) sending messages to smaller cubes to do sth
// hw / ii. change colour coroutine -> unity example
// hw / iii. raycasting-> instead of changing colour to what is front-> destroy it (turn off mesh renderer/turn scale to(0,0,0))

public class EventManager : MonoBehaviour 
{
public bool seen = false;
// Use this for initialization
void Start () 
{

}

// Update is called once per frame
    void Update () 
    {
    if(!seen)
        {
        GetComponent<MeshRenderer>().material.color = Color.white;

        }
        else
        {
        GetComponent<MeshRenderer>().material.color = Color.red;

     }
  }
}
