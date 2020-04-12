using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
	public Animator animator;

    public void changeScroll(bool isScrolling)
	{
		animator.SetBool("isScrolling", isScrolling);
	}
}
