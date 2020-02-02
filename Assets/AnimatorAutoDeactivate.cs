using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAutoDeactivate : MonoBehaviour
{

    public float delay;
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime + delay >= anim.GetCurrentAnimatorStateInfo(0).length)
        {
            gameObject.SetActive(false);
        }    
    }
}
