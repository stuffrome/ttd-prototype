using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBlessing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
        if(other.name == "Player"){
            Blessing blessing;
            switch(Random.Range(0, 3)){
                case 0: 
                    blessing = new Phantm();
                    break;
                case 1:
                    blessing = new Thunder();
                    break;
                case 2:
                    blessing = new Reverse();
                    break;
                // case 3:
                //     blessing = new Kick();
                //     break;
                default:
                    blessing = new Blessing();
                    break;
            }
            other.GetComponent<Player>().SetBlessing(blessing);
            Destroy(gameObject);
        }
    }
}
