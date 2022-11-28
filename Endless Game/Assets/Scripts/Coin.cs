using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime,0,0);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Coin");
            PlayerManager.numberOfCoins++;
            Destroy(gameObject);
        }
    }
}
