using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Questions
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public Question[] questions;

    // instance
    public static Questions instance;

    void Awake()
    {
        // set instance to be this script
        instance = this;
    }
}
