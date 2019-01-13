using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScore : MonoBehaviour {

    public static int score;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        text.text = "SCORE: " + score;
    }

    // Use this for initialization
    void Start () {
		
	}
	

}
