using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session1Homework : MonoBehaviour
{
    // i.declare a int variable and set a value
    int myInteger = 3;

    // ii.declare a float variable and set a value
    float myFloat = 0.35f;

    // iii.declare a string variable and set a value
    string myName = "Evangelia";
   
    // v.declare an array
    int[] myNumbers = new int[10];

    // vi.declare a list
    List<float> myFloatList = new List<float>();

    // viii.create a dictionary
    Dictionary<string, string> citiesOfEurope = new Dictionary<string, string>();


	void Start () 
    {

        // v.initialize an array
        for (int i = 0; i < 10; i++)
        {
            myNumbers[i] = i;

        }

        // vi.initialize a list
        myFloatList.Add(0.15f);
        myFloatList.Add(2.3f);
        myFloatList.Add(5);
        
        // viii.initialize a dictionary
        citiesOfEurope.Add("France", "Paris");
        citiesOfEurope.Add("France", "Lyon");
        citiesOfEurope.Add("France", "Bordeaux");
        citiesOfEurope.Add("Spain","Barcelona");
        citiesOfEurope.Add("Spain", "Madrid");
        citiesOfEurope.Add("Germany", "Frankfurt");


        /*   in every case we can replace the variable type
         *   with the keyword "var", whith which we declare
         *   whatever  and c# recognizes the specific type by the given value
         *   if we hover over the "var" kayword we can see the value type in each case
         */
        var anInteger = 3;
        var aFloat = 0.35f;
        var aName = "Evangelia";

    }

    void Update () 
    {
		
	}

    // iv.create a function that prints the declared variables
    public void PrintTheVariables()
    {
        Debug.Log(myInteger.ToString() + " , " + myFloat.ToString() + " , " + myName);
        
    }


}
