using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Session3HomeworkEvangelia : MonoBehaviour
{
    // i. Create a cube and move it across the screen
    // two possible solutions (i.a. -> continuous movement / i.b. -> stepwise movement - commented out)

    public GameObject movingCube;
    int counter = 0;
    bool moveUp = true;
    bool moveDown = false;


    // i.b. variables for stepwise movement
    /*

    public float timer;
    public int newPosition;
    
    */

    void Start()
    {

    }

    void Update()
    {
    
        // i. move the cube across the scene (up&down -> continuous movement)
        if (moveUp == true)
        {
            if (counter <= 15)
            {
                movingCube.transform.Translate(Vector3.up);
                counter++;
            }
            else
            {
                moveUp = false;
                moveDown = true;
                counter = 0;
            }
        }
        if (moveDown == true)
        {
            if (counter <= 15)
            {
                movingCube.transform.Translate(Vector3.down);
                counter++;
            }
            else
            {
                moveUp = true;
                moveDown = false;
                counter = 0;
            }


            // ii. create a cube and change its color when space is pressed or mouse is pressed
            if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.Mouse0)))
            {
                movingCube.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
            }


            // i.b. stepwise movement -> cube changes randomnly positions depending on time declared in unity in newPosition variable
            /*

            timer += Time.deltaTime;
            float myX = movingCube.transform.position.x + (Random.Range(-10, +10));
            float myY = movingCube.transform.position.y + (Random.Range(-10, +10));

            if (timer >= newPosition)
            {
                movingCube.transform.Translate(myX, myY, 0f);
                timer = 0;
            }
            
            */

        }


    }

}