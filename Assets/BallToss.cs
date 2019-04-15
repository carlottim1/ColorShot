using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallToss : MonoBehaviour {

    public Rigidbody rb;
    public Renderer ball;
    public bool newBall = false;
    public float forwardForce = 200f;
    public float backwardForce = -200f;
    public Color nextColor;
    public bool start = true;
    public Text scoreText;
    private float minusScore = -15f;
    private float plusScore = 50f;
    public static float totalScore = 0f;
    public string displayScore = "0";
    public Text timerText;
    private float startTime;
    public Text finalScoreText;
    public bool finish = false;
    public bool controlsOn = true;
    public string seconds = "0";
    public float t = 0f;
    // Start is called before the first frame update
    void Start()
    {

        
        // Debug.Log("Hsello, world");
        if (start == true)
        {
            start = false;
            startTime = Time.time;
            totalScore = 0f;
            nextColor = Color.green;
            //rb.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.GetComponent<Renderer>().material.SetColor("_Color", nextColor);
        //add force for ball toss
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //move forward 
        if (controlsOn == true)
        {
            if (Input.GetKey("w"))
            {
                //Debug.Log("Player moved forward");
                rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            }
            //move right
            if (Input.GetKey("d"))
            {
                //Debug.Log("Player moved right");
                rb.AddForce(forwardForce * Time.deltaTime, 0, 0);
            }
            //move left 
            if (Input.GetKey("a"))
            {
                //Debug.Log("Player moved left");
                rb.AddForce(backwardForce * Time.deltaTime, 0, 0);
            }
            //move back
            if (Input.GetKey("s"))
            {
                //Debug.Log("Player moved back");
                rb.AddForce(0, 0, backwardForce * Time.deltaTime);
            }
            //move up
            if (Input.GetKey("space"))
            {
                //Debug.Log("Player moved up");
                rb.AddForce(0, forwardForce * Time.deltaTime, 0);
            }
            if (Input.GetKey("z"))
            {
                //Debug.Log("Player moved down");
                rb.AddForce(0, backwardForce * Time.deltaTime, 0);
            }
            if (newBall == true)
            {
                Destroy(rb, 0f);
                newBall = false;
                rb.GetComponent<Renderer>().material.SetColor("_Color", nextColor);
                Instantiate(rb, new Vector3(2.86f, 2.5f, -8.838f), transform.rotation);
                
            }
            seconds = ((int)t % 60).ToString();
        }
            scoreText.text = "Score: " + displayScore;
             t = Time.time - startTime;
            float minuteCheck = (t / 60);
            string minutes = (t / 60).ToString();
            //string seconds = ((int)t % 60).ToString();
            timerText.text = "Time: " + seconds;
        
        if (minuteCheck >= 1 && start == false)
        {
            scoreText.color = Color.white;
            scoreText.fontSize = 20;
            finalScoreText.text = "Final Score: " + displayScore;
            controlsOn = false;
            //PlayerPrefs.SetInt("Total Score", (int)totalScore);
            if((int)t % 60 > 10){
                Debug.Log("Hello World");
                t = 0f;
                minuteCheck = 0f;
                minutes = "";
                seconds = "";
                start = true;
                startTime = 0f;
                SceneManager.LoadScene("End_Screen");
                SceneManager.UnloadScene("Color Shot");
            }
        }


    }
    void OnCollisionEnter(Collision col)
    {
        //Color mycolor = rb.GetComponent<Renderer>().material.color;
        Debug.Log(rb.GetComponent<Renderer>().materials[0]);
        //Red conditions
        if (rb.GetComponent<Renderer>().material.color == Color.red)
        {
            if (col.gameObject.name == "RedR1" || col.gameObject.name == "RedR2" || col.gameObject.name == "RedR3")
            {
                totalScore = totalScore + plusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                newBall = true;
                nextColor = Color.blue;
                // rb.move(2.86, 1.166, -8.838);
            }
        }
        if (rb.GetComponent<Renderer>().material.color != Color.red)
        {
            if (col.gameObject.name == "RedR1" || col.gameObject.name == "RedR2" || col.gameObject.name == "RedR3")
            {
                totalScore = totalScore + minusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                newBall = true;
                nextColor = Color.blue;
                // rb.move(2.86, 1.166, -8.838);
            }
        }
        //Blue conditions 
        if (rb.GetComponent<Renderer>().material.color == Color.blue)
        {
            if (col.gameObject.name == "BlueR1" || col.gameObject.name == "BlueR2" || col.gameObject.name == "BlueR3")
            {
                totalScore = totalScore + plusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                newBall = true;
                // rb.move(2.86, 1.166, -8.838);
               nextColor = Color.yellow;
            }
        }
        if (rb.GetComponent<Renderer>().material.color != Color.blue)
        {
            if (col.gameObject.name == "BlueR1" || col.gameObject.name == "BlueR2" || col.gameObject.name == "BlueR3")
            {
                totalScore = totalScore + minusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                newBall = true;
                // rb.move(2.86, 1.166, -8.838);
                nextColor = Color.yellow;
            }
        }
        //Green conditions 
        if (rb.GetComponent<Renderer>().material.color == Color.green)
        {
            if (col.gameObject.name == "GreenR1" || col.gameObject.name == "GreenR2" || col.gameObject.name == "GreenR3")
            {
                totalScore = totalScore + plusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                nextColor = Color.red;
                newBall = true;
                // rb.move(2.86, 1.166, -8.838);
               
            }
        }
        if (rb.GetComponent<Renderer>().material.color != Color.green)
        {
            if (col.gameObject.name == "GreenR1" || col.gameObject.name == "GreenR2" || col.gameObject.name == "GreenR3")
            {
                totalScore = totalScore + minusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                nextColor = Color.red;
                newBall = true;
                // rb.move(2.86, 1.166, -8.838);

            }
        }
        //Yellow Conditions
        if (rb.GetComponent<Renderer>().material.color == Color.yellow)
        {
            if (col.gameObject.name == "YellowR1" || col.gameObject.name == "YellowR2" || col.gameObject.name == "YellowR3")
            {
                totalScore = totalScore + plusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                newBall = true;
                nextColor =  Color.magenta;
                // rb.move(2.86, 1.166, -8.838);
            }
        }
         if(rb.GetComponent<Renderer>().material.color != Color.yellow)
            {
            if (col.gameObject.name == "YellowR1" || col.gameObject.name == "YellowR2" || col.gameObject.name == "YellowR3")
            {
                totalScore = totalScore + minusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                newBall = true;
                nextColor = Color.magenta;
                // rb.move(2.86, 1.166, -8.838);
            }
        }
        //Purple Conditions 
        if (rb.GetComponent<Renderer>().material.color == Color.magenta)
        {
            if (col.gameObject.name == "PurpleR1" || col.gameObject.name == "PurpleR2" || col.gameObject.name == "PurpleR3")
            {
                totalScore = totalScore + plusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                newBall = true;
                // rb.move(2.86, 1.166, -8.838);
               nextColor = Color.green;
            }
        }
        if (rb.GetComponent<Renderer>().material.color != Color.magenta)
        {
            if (col.gameObject.name == "PurpleR1" || col.gameObject.name == "PurpleR2" || col.gameObject.name == "PurpleR3")
            {
                totalScore = totalScore + minusScore;
                displayScore = totalScore.ToString();
                //Destroy(rb, 0.1f);
                Debug.Log("Collision Detected");
                newBall = true;
                // rb.move(2.86, 1.166, -8.838);
                nextColor = Color.green;
            }
        }

    }
}
