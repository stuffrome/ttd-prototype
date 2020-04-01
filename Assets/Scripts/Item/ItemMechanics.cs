using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputDetection;

public class ItemMechanics : MonoBehaviour
{
    private Environment env1, env2;
    private InputDetector p1Input, p2Input;
    private enum Player{P1, P2}

    // Start is called before the first frame update
    void Start()
    {
        env1 = GetComponent<GameManager>().env1;
        env2 = GetComponent<GameManager>().env2;      
        p1Input = env1.GetPlayerObject().GetComponent<InputDetector>();
        p2Input = env2.GetPlayerObject().GetComponent<InputDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        DetermineInteraction(Player.P1);
        DetermineInteraction(Player.P2);
    }

    private void DetermineInteraction(Player player){
        if(GetInput(player).HasValue && GetInput(player).Value == InputAction.Item){
            if(GetLane(player) == GetEnemyLane(player)){HitEnemy(player);}
        }
    }

    private InputAction? GetInput(Player player){
        if(player == Player.P1){return p1Input.DetectInput();}
        if(player == Player.P2){return p2Input.DetectInput();}
        return null;
    }
    private int? GetLane(Player player){
        if(player == Player.P1){return env1.player.GetLane();}
        if(player == Player.P2){return env2.player.GetLane();}
        return null;
    }
    private int? GetEnemyLane(Player player){
        if(player == Player.P1){return -1*env2.player.GetLane();}
        if(player == Player.P2){return -1*env1.player.GetLane();}
        return null;
    }
    private void HitEnemy(Player player){
        if(player == Player.P1){env2.player.Hit();}
        else if(player == Player.P2){env1.player.Hit();}
    }
}
    
    // [SerializeField]
    // private Rigidbody weapon;
    // private Transform spawnPoint;
    // private Vector3 spawnVector;
    // private Rigidbody clone;

    // shoot projectile to enemy
    // spawnPoint = players[0].transform;
    // spawnVector = new Vector3(spawnPoint.position.x, spawnPoint.position.y+1, spawnPoint.position.z+3);
    // clone = Instantiate(weapon, spawnVector, spawnPoint.rotation);            
    // clone.velocity = spawnPoint.TransformDirection(Vector3.forward*20);