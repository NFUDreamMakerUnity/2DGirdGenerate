using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GirdWallBuilder.instence.GenerateGird();
    }
	
	// Update is called once per frame
	void Update () {
        GirdWallBuilder.instence.BuildWall();
    }
}
