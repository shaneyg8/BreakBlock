using UnityEngine;
using System.Collections;

public class Brickslvl2 : MonoBehaviour {

    public GameObject brickParticle;

    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GMlvl2.instance.DestroyBlock();
        Destroy(gameObject);
    }
}