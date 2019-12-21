using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    private Animator playerAnimator;
    public Transform objectToGrab;
    private AnimatorStateInfo currentState;
    private CapsuleCollider capsule;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        currentState = playerAnimator.GetCurrentAnimatorStateInfo(0);
        playerAnimator.SetFloat("Speed", Input.GetAxis("Vertical"));
        playerAnimator.SetFloat("Direction", Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space) && currentState.IsName("Locomotion"))
            playerAnimator.SetTrigger("Jump");
        if (Input.GetKeyDown(KeyCode.Q))
            playerAnimator.SetTrigger("Wave");
        if (Input.GetKeyDown(KeyCode.G))
            playerAnimator.SetTrigger("Grab");
        if (currentState.IsName("Jump"))
        {
            Physics.gravity = Vector3.down * (playerAnimator.GetFloat("Gravity"));
            capsule.height = playerAnimator.GetFloat("CapsuleHeight");
        }
        else
        {
            capsule.height = 1.11f;
            Physics.gravity = Vector3.down * 9.81f;
        }
    }

    // Apply Inverse Kinematics to move the model's hand to the position
    // of the desired object to grab without having to change the whole animation
    void OnAnimatorIK()
    {
        //Just apply IK if the model is trying to grab something
        if (currentState.IsName("GrabNeutral"))
        {
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
            playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, objectToGrab.position);
            playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, objectToGrab.rotation);
        }
    }
}
