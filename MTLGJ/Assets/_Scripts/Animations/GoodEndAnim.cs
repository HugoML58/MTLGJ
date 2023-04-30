using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GoodEndAnim : MonoBehaviour
{
    [SerializeField]
    GameObject rocketCam;

    Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
        rocketCam.GetComponent<CinemachineVirtualCamera>().enabled = true;
        Animator.SetBool("BadEnd", false);
        Animator.SetBool("GoodEnd", true);
        Debug.Log("good end");
    }
}
