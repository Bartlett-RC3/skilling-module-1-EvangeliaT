using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session4Evangelia : MonoBehaviour 
{
   //variables
    public GameObject prefabReference;
    //coroutine variable -> we can use it to fade objects/instantiate sth based on time/...
    IEnumerator createPrefabs;


    // Use this for initialization
    void Start () 
    {
     
        for (int i = 0; i < 10; i++) // makes 10 prefabs (copies)
        {
            //How do we instantiate(make) a new prefab? - give an object position, rotation and parent
            Vector3 prefabPostition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            Quaternion prefabRotation = Quaternion.identity;
            GameObject myPrefab = Instantiate(prefabReference, prefabPostition, prefabRotation);

            //change the colour of the children (spheres->they belong to the parent-cube at the hierarchy) -> blue
            foreach (Transform child in myPrefab.transform)
            {
                child.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
            }
           
             //make green the cube (the parent(folder))
            myPrefab.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);

        }
        createPrefabs = DropPrefabsFromHeight();
	}
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine(createPrefabs);
        Debug.Log(Time.time);
        if (Time.time > 5)
        {
            StopCoroutine(createPrefabs);
            StopAllCoroutines();
        }
    }
    // implement the coroutine
    IEnumerator DropPrefabsFromHeight()
    {
        while (true)
        {
            Vector3 prefabPos = new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 10f), Random.Range(-10f, 10f));
            Quaternion prefabRot = new Quaternion(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90), 1);
            Instantiate(prefabReference, prefabPos, prefabRot);
            yield return new WaitForSeconds(5); //condition to get out of the while loop - after 5 seconds, because it is always true->infinite
        }
    }
}

