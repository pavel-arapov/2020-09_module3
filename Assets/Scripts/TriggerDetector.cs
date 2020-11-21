using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public bool inTrigger;
    public bool isDeadArea = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadArea")) {
            isDeadArea = true;
        }
        inTrigger = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
