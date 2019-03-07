// Session 2: Conditionals, Loops and Classes 
// UCL RC3 12Nov2017
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using Something -> libraries (bunch of classes)

//LOOK AT PLATONIC OBJECTS (for workshop)

public class Session2Evangelia : MonoBehaviour {

    int number1 = 10;
    int number2 = 20;
    int number3 ;

    bool someBool = false;

    string someName = "name";

    string[] tutorNames = { "Dave", "Tyson", "Jordi", "Octavian", "Panos" };

    void Start()
    {


        // Navigate data -> iterative for loop (variables that counts -- where it ends -- what is the increment)
        //for (int i = tutorNames.Length - 1; 1 >= 0;, i--)
        for (int i = 0; i <= tutorNames.Length - 1; i++)
        {
            Debug.Log("A tutor is:" + tutorNames[i]);
        }

        for (int counter=0; counter <= number2; counter++)
        {
            Debug.Log("Counter..." + counter);

        }

        // foreach loop
        // a bit more easy to read than iterrative for loops
        foreach (string tutorName in tutorNames) 
        {
            Debug.Log(tutorName);

        }


        //conditions
        if (number1 < number2) // question
        {
            //action if true
            Debug.Log("Number 1 is smaller than number 2");
        }
            else 
        {
            //action if false
            Debug.Log("Number 2 is smaller than number 1");
        }
        //Questions we can ask
        // if sth is smaller or bigger
        // < >

        //if sth is equal to sth else
        // ==

        //asking multiple questions

        if (number2>number1 && someBool==true)
        {
            Debug.Log("answer to both questions is yes");
        }

        if (number2>number1)
        {
            if (someBool==true)
            {
                Debug.Log("answer to both questions is yes"); //this is easier to understand than long conditions all in one

            }

        }

        if (number2>number1 || someBool ==true)
        {
            Debug.Log("Answer to one of the questions is true");

        }
        // complex questions by concatenation and by embedding sub questions

        if((number1<number2 && someBool == true) && (someBool ==true && someName == "name" )) //try to avoid such complex situations
        {
            Debug.Log("This is too confusing. SImplify please");

        }

        //SHORTHAND IF

        number3 = (number1 < number2) ? 100 : 200;
        //         Question -- value if is true -- value if is false
        // based on the answer of the question we assign a value to a third variable



    }



}


   
	
