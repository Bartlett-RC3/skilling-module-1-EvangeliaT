using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session4Homework : MonoBehaviour
{
    //Variables
    public GameObject cubePrefab;
    private GameObject thisPrefab;
    IEnumerator changeColourCoroutine;


    void Start()
    {
        thisPrefab=Instantiate(cubePrefab);
        changeColourCoroutine = ChangeColour();
        StartCoroutine(changeColourCoroutine);
       
         if (Time.time > 3)
        {
            StopCoroutine(changeColourCoroutine);
            StopAllCoroutines();
        }
    }

    //Coroutines
    IEnumerator ChangeColour()
    {
       while (true)
        {
            thisPrefab.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
            yield return new WaitForSeconds(3);
        }
    }

}
