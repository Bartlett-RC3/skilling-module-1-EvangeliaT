using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// iii. write a dog class 

public class Dog
{
    // variables
    public string name;
    public int age;
    public string breed;
    public string furColour;
    public float weight;
    private bool hungry;
    private bool clean;
    public bool guideDog;

    // constructors
    public Dog(string _name, int _age, string _breed, string _furColour, float _weight, bool _guideDog)
    {
        this.name = _name;
        this.age = _age;
        this.breed = _breed;
        this.furColour = _furColour;
        this.weight = _weight;
        this.guideDog = _guideDog;
        this.hungry = true;
        this.clean = true;
    }

    // functions (methods)
    public void Running ()
    {
        weight = weight - 0.3f;
        hungry = true;
        clean = false;
    }

    public void Eating()
    {
        weight = weight + 0.2f;
        hungry = false;
    }

    public void Grooming()
    {
        clean = true;
    }
    public string GetDogsName()
    {
        return name;
    }
}

public class Session2Homework : MonoBehaviour
{
	void Start () 
    {
        // iii. initialize instances of the dog class

        Dog Moly = new Dog("Moly", 5 , "Bichon Frise", "white" , 5.8f, false);
        Dog Monet = new Dog("Monet", 4, "Boston Terrier", "black", 4.2f, false);

        Debug.Log("A dog's name is : " + Moly.GetDogsName());
        Debug.Log("A dog's name is : " + Monet.GetDogsName());

        // ii. write a for loop (calculates the sum of all even numbers until 100)

        int sum = 0;
        for (int i = 0; i <= 100; i+=2)
        {
            sum = sum + i;
        }
       
    }

    void Update () 
    {
		
	}

    // i. write a function that uses a condition 

    void PrintTheMaxNumber(int number1, int number2, int number3)
    {
        if (number1 < number2)
        {
            if (number2 < number3)
            {
                Debug.Log("The max number is : " + number3);
            }
            else
            {
                Debug.Log("The max number is : " + number2);
            }
        }
        else
        {
            Debug.Log("The max number is : " + number1);
        }


    }
   
}
