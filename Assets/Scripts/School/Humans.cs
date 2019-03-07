// My custom class (object)
using UnityEngine;

public class Humans : MonoBehaviour // monobehaviour -> the uinty implementation inside a class
                                   //interface -> is meant to be generic, so that other classes use it
                                   // we don't actually use interfaces, we use objects that implement interfaces
                                  //INTERFACE -> a level above class
                                   // we decide which part of an interface we will use in our code 
{
    //properties 
    string name = "Evangelia";
    int age = 32;
    float height = 170.5f;
    float energy = 100;


    //behaviours (or actions)
    void Walking()
    {

    }

    void Sleeping()
    {

    }

    void Eating()
    {

    }

    void WorkingOut()
    {
        energy++;
    }

}