using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session1Evangelia : MonoBehaviour {

    //search for GENERIC variable (var)
    //search for RECURSIVE(?) functions

    // at the start we only need to allocate memory and then declare the specific items after the "Start"

    //1.Variables
    //scope -- type -- name -- one value


    //NUMBERS
    
    public int myInteger = 145;
    int largestInteger = int.MaxValue; // max value of an integer a computer can store
    int smallestInteger = int.MinValue;

    double myDouble = 54.3;
    double maxDouble = double.MaxValue;

    float myFloat = 32.546f;

    //TEXT
    //LOGICAL VARIABLES (booleans)

    //2.DATA STRUCTURES --> merit/dinstiction if I investigate more than arrays/lists
    //Scope -- type -- many values

    //ARRAY
    //can be of 1/2/3/multiple dimension
    public int[] myIntArray = { 1, 2, 3, 4, 5, 6 }; // i will get a "NULL" if I ask for myIntArray[6] - because this array has 5 elements
    int[] twentyElementsArray = new int[20];
    int[,] xyArray = new int[4, 5];

    double[] doubleArray = { 10.4, 11.23, 45, 72.9 }; // can also take an integer because each integer is a double


    //LIST -> don't care about size
    List<int> myList = new List<int>(); //make a new list of integers

    //DICTIONARY -> creates a set of a rules through which we can search of smth
    // has an imbededd organzational logic -> we can set this logic
    Dictionary<string, string> movingAnimals = new Dictionary<string, string>();

    //3. Functions 

    // Use this for initialization
    void Start () {

        //array adding values
        myIntArray[2] = 300;

        //array retrieving values
        Debug.Log(myIntArray[1].ToString());

        //List adding values -> I can only add values at the end of the list
        myList.Add(4321);
        myList.Add(43);
        myList.Add(321);


        //List retrive values
        Debug.Log(myList[2].ToString());
        Debug.Log(myList[myList.Count-1].ToString());   //get the last item of a list (added the "-1" because the index is one less than the amount of the elements)


        //Clearing the List (&repurpose)
        myList.Clear();


        //Dictionary
        movingAnimals.Add("flying", "eagle");
        movingAnimals.Add("flying", "parrot");
        movingAnimals.Add("walking", "human");
        movingAnimals.Add("walking", "dog");

        if (movingAnimals.ContainsKey("flying")){
            Debug.Log("A flying animal is" + movingAnimals.Values);
             }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //example -> number addition function
    float NumberAddition(float a, float  b)
    {

        return a + b; // it needs to return something (float) -> a void is a function that does not return anything
       /* float additionResult = a + b;
        return additionResult; */

    }
    void PrintSomeNumbers() // does not return anything
                            // a function does not always have to have inputs
    {
        Debug.Log(myList[0]);
        Debug.Log(myInteger);

    }




}
