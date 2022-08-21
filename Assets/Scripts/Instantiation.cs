using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
   // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public static Instantiation obj;

    void Awake()
    {
        obj = this;
    }

    // This script will simply instantiate the Prefab when the game starts.
    public void instantiatePrefab(Vector3 transform)
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, transform, Quaternion.identity);
    }
}
