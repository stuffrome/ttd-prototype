using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollOnClick : MonoBehaviour
{
	public void PlayAnimation()
	{
		GetComponent<Animator>().SetBool("Scroll", true);
	}
}
