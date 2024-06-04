using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour

{
    public float speed = 10;
    public TMP_Text pointsLeft;
    public TMP_Text pointsRight;

    public Camera MainCamera;
    public Camera camera2;

    public GameObject power;

    public GameObject power2;
    int playerA_points=0;
    int playerB_points=0;
    public float slowDownFactor = 0.4f;
    

    // Start is called before the first frame update
    void Start()
    {
        if((playerA_points>=3)||(playerB_points>=3))
        {
            SceneManager.LoadScene(2);
        }

        float x = Random.Range(0,2) == 0 ? -1:1;
        /*
        float x = Random.Range(0,2);  
        if(x == 0)
        {
            x = -1;
    
        }else
        {
            x = 1;
        }
        */
        float y = Random.Range(0,2) == 0 ? -1:1;
        GetComponent<Rigidbody>().velocity = new Vector2(speed*x, speed*y);
        pointsLeft.SetText(playerA_points.ToString());
        pointsRight.SetText(playerB_points.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)

    {
       
        
        if(hit.gameObject.name=="gauche")
        {
            transform.position = new Vector3(0,3,0);
            playerB_points++;
            Start();
        }else if(hit.gameObject.name=="droite")
        {
            transform.position = new Vector3(0,3,0);
            playerA_points++;
            Start();
        }else if(hit.gameObject.name=="PowerUp")
        {
            
            MainCamera.enabled = false;
            camera2.enabled = true;

            power.SetActive(true);
            Destroy(power);
            StartCoroutine(PowerEnd(5));
            
        }
  
    }

    void OnTriggerEnter(Collider touch){

        if(touch.gameObject.name=="PowerUp2"){
            speed = speed * slowDownFactor;
            Destroy(touch.gameObject);
            StartCoroutine(ReduceSpeed(5));
        }
    }

    IEnumerator PowerEnd(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        MainCamera.enabled = true;
        camera2.enabled = false;
    }

     IEnumerator ReduceSpeed(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        speed = 10;
            
        }
}



