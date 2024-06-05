using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
 public GameObject[] listOfPoints;


      void Start()
    {
        int luckNumber = Random.Range(0, listOfPoints.Length);
        //this.transform.position = listOfPoints[luckNumber].transform.position;
        //this.transform.position = new Vector3(RandomNumber, RandomNumber, 0);
        int destroyTime = Random.Range(1, 6);
        StartCoroutine(DestroyPrefab(destroyTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyPrefab(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Debug.Log("I was here!");
        Destroy(this.gameObject);
    }
     
}
