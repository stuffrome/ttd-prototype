using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public static float timeLeft = 3;

    public TextMeshProUGUI countText1;
    public TextMeshProUGUI countText2;

    public Environment env1, env2;

    void Start()
    {
        countText1.gameObject.SetActive(true);
        countText2.gameObject.SetActive(true);
    }

    void Update()
    {
        if (timeLeft > -1)
        {
            timeLeft -= Time.deltaTime;

            env1.player.SetMoving(false);
            env2.player.SetMoving(false);

            if (timeLeft > 2)
            {
                countText1.text = "3";
                countText2.text = "3";
            }
            else if (timeLeft > 1)
            {
                countText1.text = "2";
                countText2.text = "2";
            }
            else if (timeLeft > 0)
            {
                countText1.text = "1";
                countText2.text = "1";
            }
            else
            {
                env1.player.SetMoving(true);
                env2.player.SetMoving(true);
                countText1.text = "GO!";
                countText2.text = "GO!";
            }
        }
        else
        {
            countText1.gameObject.SetActive(false);
            countText2.gameObject.SetActive(false);
            Destroy(this);
        }

    }
}
