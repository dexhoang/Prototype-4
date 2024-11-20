using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {
        Debug.Log("YOU WIN!");
    }
}
