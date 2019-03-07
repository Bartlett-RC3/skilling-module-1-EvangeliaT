using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class session4RaycastingEvangelia : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Raycasting steps

        //step 1 -> create ray
        Vector3 rayCastingDirection = transform.forward;

        //step2 -> see what object is in front of me
        RaycastHit objectInFront;

        // step3-> do sth with the obj in front of me 
        if(Physics.Raycast(transform.position, rayCastingDirection, out objectInFront))
        {
            Debug.Log("object in Front is:" + objectInFront.transform.name);
            objectInFront.transform.GetComponent<EventManager>().seen = true; //calls a function from the "eventManager" script that holds the initial colour
        }

	}
}
