using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }
    internal void SetGrip(float v){
        gripTarget = v;
    }
    internal void SetTrigger(float v){
        triggerTarget = v;
    }
    void AnimateHand(){
        if (gripCurrent != gripTarget){
            gripCurrent = Mathf.MoveTowards(gripCurrent,gripTarget, Time.deltaTime *speed);
            animator.SetFloat(animatorGripParam,gripCurrent);
        }

        if (triggerCurrent != triggerTarget){
            triggerCurrent = Mathf.MoveTowards(triggerCurrent,triggerTarget, Time.deltaTime *speed);
            animator.SetFloat(animatorTriggerParam,triggerCurrent);
        }
    }

}
