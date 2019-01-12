using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    public int score = 0;

    void Start()
    {
        GameObject _hp = GameObject.Find("HP");
        GameObject _score = GameObject.Find("Score");

        // string _hpval = _hp.GetComponent<Text>();
    }
}
