using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            Debug.Log("Pressing!");
        }
        else {
            Debug.Log("-");
        }
    }
}