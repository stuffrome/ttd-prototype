using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputDetection;

public class Multiplayer : MonoBehaviour
{

    private GameObject[] players;
    private InputDetector[] inputDetectors;
    
    private InputAction? inputAction;
    private int currentLane;
    [SerializeField]
    private Rigidbody weapon;
    private Transform spawnPoint;
    private Vector3 spawnVector;
    private Rigidbody clone;   


    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        inputDetectors = new InputDetector[players.Length];
        for(int i=0; i<players.Length;i++){
            inputDetectors[i] = players[i].GetComponent<InputDetector>();
        }
    
    }

    // Update is called once per frame
    void Update()
    {       
        DetermineInteraction();
    }

    private void DetermineInteraction(){        

        

        //action of player0 to player1
        inputAction = inputDetectors[0].DetectInput();
        if(inputAction.HasValue && inputAction.Value == InputAction.Ability){
            //do lane-based action towards player1            
            currentLane = players[0].GetComponent<PlayerMovement>().getLane();            

            // for auto hit to enemy if in correct lane
            // if(currentLane == -1 * players[1].GetComponent<PlayerMovement>().getLane()){
            //     players[1].GetComponent<PlayerMovement>().kick();
            //     players[1].GetComponent<PlayerScript>().coins-=Constants.coinLoss;
            // }           

            // shoot projectile to enemy
            spawnPoint = players[0].transform;
            spawnVector = new Vector3(spawnPoint.position.x, spawnPoint.position.y+1, spawnPoint.position.z+3);
            clone = Instantiate(weapon, spawnVector, spawnPoint.rotation);            
            clone.velocity = spawnPoint.TransformDirection(Vector3.forward*20); 
        }

        //action of player1 to player0 
        inputAction = inputDetectors[1].DetectInput();
        if(inputAction.HasValue && inputAction.Value == InputAction.Ability){
            // do lane-based action towards player0
            currentLane = players[1].GetComponent<PlayerMovement>().getLane();        

            // for auto hit to enemy if in correct lane
            // if(currentLane == -1 * players[0].GetComponent<PlayerMovement>().getLane()){
            //     players[0].GetComponent<PlayerMovement>().kick();
            //     players[0].GetComponent<PlayerScript>().coins-=Constants.coinLoss;
            // }

            // shoot projectile to enemy
            spawnPoint = players[1].transform;
            spawnVector = new Vector3(spawnPoint.position.x, spawnPoint.position.y+1, spawnPoint.position.z+3);
            clone = Instantiate(weapon, spawnVector, spawnPoint.rotation);            
            clone.velocity = spawnPoint.TransformDirection(Vector3.forward*20); 
        }
    }
}
