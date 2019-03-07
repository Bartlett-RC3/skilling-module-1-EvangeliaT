using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session3Evangelia : MonoBehaviour {
    
    public GameObject cubePrefab;
    public GameObject light;
    public GameObject objectReference;
    public int spacing = 10;
    public int gridX = 10;
    public int gridY = 10;

    //difference between awake and start -> awake happens whenever I start unity, regardless of play
    // start gets executed as I press the play in unity (only once) -> I can reset the game by "start"

    //computers measure time in frames
    //to use any time related things we use "time"


    private void Awake()
    {

    }

    // Use this for initialization
    void Start () 
    {
        for (int i = 0; i < gridX; i++)
        {
            for (int j = 0; j <gridY;j++)
            {
                Instantiate(cubePrefab, new Vector3(i * spacing, j * spacing, 0), Quaternion.identity, this.transform); //this instances will be children of the transform that holds the game (this keyword)
            }
        }



	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log("This computer can render a frame in:" + Time.deltaTime);
        Debug.Log("Since I started playing the game this amount of time has passed:" + Time.timeSinceLevelLoad);
        Debug.Log("Computer has counted this amount of frames: " + Time.frameCount);

       /* Time.deltaTime(); // how many time has passed since last frame
        Time.realtimeSinceStartup(); //
        Time.frameCount(); 
        */

        //TRANSLATION -> move in direction and distance of translation (expects a vector (x,y,z) and a distance)
        //Move children in x axis
        foreach(Transform child in this.transform)
        {
            child.Translate(Random.value,0,0);
        }

        //ROTATION
        //Rotate children gameobjects around y axis 
        foreach(Transform child in this.transform)
        {
            child.RotateAround(Vector3.up, Random.value);
        }

        //SCALING  -> is set up by a vector (Xscale/Yscale/Zscale)
        foreach(Transform child in this.transform)
        {
            child.localScale = new Vector3(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
        }

        //record the cubes original scale

        Vector3[] originalScale = new Vector3[this.transform.childCount];
        for (int i = 0; i < transform.childCount;i++)
        {
            originalScale[i] = transform.GetChild(i).localScale;
        }


        //KEYBORD INPUT

        if (Input.GetKey(KeyCode.Space))
        {
            //if i have pressed space -> make temporarily the cubes larger 5 times

            foreach(Transform child in this.transform)
            {
                child.localScale = child.localScale * 5f;
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i);
            }

            //MOUSE PRESSED
            //0->left mouse / 1->right mouse / 2->middle mouse
            if (Input.GetMouseButton(0))
            {
                light.GetComponent<Light>().color = new Color(Random.Range(0,255), Random.Range(0, 255), Random.Range(0,255));  
                    //getting components attached to a gameObject from unity
                    //color has rgb values
            }

            objectReference.transform.Translate(Vector3.up);

            //if I have an error -> copy the error code from call stack in unity to google-> not the whole code
            // stack overflow-> people ask for errors

        }

    }
}