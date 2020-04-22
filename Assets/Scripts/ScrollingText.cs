using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
	public Animator animator;

    public void changeScroll(bool isScrolling)
	{
		animator.SetBool("isScrolling", isScrolling);

		if(!isScrolling){
			this.transform.GetChild(0).transform.position = new Vector3(-3, 72, 9.5f);
		}
	}
}
