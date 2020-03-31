using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessing : MonoBehaviour
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
            IItem item;
            switch(Random.Range(0, 3)){
                case 0: 
                    item = new Kick();
                    break;
                case 1:
                    item = new Thunder();
                    break;
                case 2:
                    item = new Reverse();
                    break;
                default:
                    item = new IItem();
                    break;
            }
            other.GetComponent<Player>().CollectItem(item);
            Destroy(gameObject);
        }
    }
}
