using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
 public GameObject[] listOfPoints;

      void Start()
    {
        int luckNumber = Random.Range(0, listOfPoints.Length);
        this.transform.position = listOfPoints[luckNumber].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     
}
