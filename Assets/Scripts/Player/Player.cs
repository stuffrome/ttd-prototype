using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int TOKEN_MAX = 10;
    private const int TOKEN_LOSS_ON_HIT = 3;

    private int tokenCount;
    private PlayerMovement movement;
    private bool moving;

    private Blessing blessing;
    private Blessing emptyBlessing = new Blessing();

    void Start()
    {
        tokenCount = 0;
        movement = gameObject.AddComponent(typeof(PlayerMovement)) as PlayerMovement;

        blessing = emptyBlessing;
    }

    public int GetLane()
    {
        return movement.GetLane();
    }

    public int GetTokens(){
        return tokenCount;
    }

    public void CollectToken()
    {
        if (tokenCount < TOKEN_MAX)
        {
            tokenCount++;
        }

        movement.SetSpeedMultiplier(1.0f + (float)tokenCount/20f);
    }

    private void LoseTokens(int count)
    {
        if (count > tokenCount)
        {
            tokenCount = 0;
        }
        else
        {
            tokenCount -= count;
        }
    }

    //----------Blessings--------------
    public Power GetPower()
    {
        return blessing.GetPower();
    }

    public void SetBlessing(Blessing newBlessing)
    {
        blessing = newBlessing;
    }

    public void UseBlessing(Player enemy)
    {
        blessing.UseBlessing(this, enemy);
        blessing = emptyBlessing;
    }

    public void Hit()
    {
        movement.Stumble();
        LoseTokens(TOKEN_LOSS_ON_HIT);
    }

    public void Reverse()
    {
        movement.Reverse();
    }

    public void SetMoving(bool moving)
    {
        if (!this.moving)
        {
            this.moving = moving;
            movement.SetMoving(moving);
        }
    }

    public void Thunder(int targetLane){
        GameObject cloud = (GameObject)Instantiate(Resources.Load("Thunder"));
        cloud.GetComponent<ThunderMovement>().lookAt = transform;
        StartCoroutine(Thunderstrike(targetLane));
        Destroy(cloud, 5f);
    }

    private IEnumerator Thunderstrike(int targetLane){
        yield return new WaitForSeconds(3f);
        if(GetLane() == targetLane) Hit();
    }

    public void Phantm(){
        CharacterController controller = GetComponent<CharacterController>();
        controller.detectCollisions = false;

        Renderer renderer = transform.GetChild(2).GetComponent<Renderer>();
        Color initColor = renderer.material.color;
        renderer.material.color = new Color(initColor.r, initColor.g, initColor.b, 0f);

        StartCoroutine(Nophantm(controller, renderer, initColor));
    }

    private IEnumerator Nophantm(CharacterController controller, Renderer renderer, Color initColor){
        yield return new WaitForSeconds(5f);
        controller.detectCollisions = true;
        renderer.material.color = initColor;
    }
}
