using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session4HWRaycasting : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private int numberOfCubes;
    [SerializeField] private float maxDistance;

    void Start()
    {

        // create aggregation of cubes
        for (int i = 0; i <= numberOfCubes; i++)
        {
            GameObject copy = Instantiate(cubePrefab);
            Vector3 pos = new Vector3(Random.Range(0, maxDistance), Random.Range(0, maxDistance), Random.Range(0, maxDistance));
            copy.transform.localPosition = pos;
        }
    }

        
     void Update()
     {
         
         //destroy cubes with mouse hit
         if (Input.GetMouseButtonDown(0))
         {

             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;

             if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                  Destroy (hit.transform.gameObject) ;
         }
    }

}




