using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject impactEffect;
    private void OnTriggerEnter(Collider collider) {
        if(!GameController.gameStarted)
        return;

        if (collider.gameObject.tag == "Player Cell")
        {
            GameObject Effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); 
            Destroy(Effect, 2.0f);
            Destroy(collider.gameObject);
            Destroy(this.gameObject);

        }
    }
}
