using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = Constants.projectileLifetime;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            other.GetComponent<PlayerScript>().coins-=Constants.coinLoss;
            other.GetComponent<PlayerMovement>().kick();
            DestroyObject();
        } else if(other.name.StartsWith("Coin")){
            //don't destroy if going through a special item
        }
        else {
            DestroyObject();
        }
    }

    private void DestroyObject(){
        Destroy(gameObject);
    }
}
