using UnityEngine;
using System.Collections;

public class Deadzonelvl2 : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        GMlvl2.instance.LoseLife();
    }
}
