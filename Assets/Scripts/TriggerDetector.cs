using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public bool inTrigger;

    void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
