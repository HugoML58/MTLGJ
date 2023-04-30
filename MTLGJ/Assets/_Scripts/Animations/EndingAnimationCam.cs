using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EndingAnimationCam : MonoBehaviour
{
    [SerializeField]
    GameObject rocketCam;

    Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
        Animator.SetBool("GoodEnd", false);
        Animator.SetBool("BadEnd", false);
        rocketCam.GetComponent<CinemachineVirtualCamera>().enabled = false;
        bool state = Animator.GetBool("GoodEnd");
        Debug.Log(state);
    }

    // Update is called once per frame
    void Update() { }

    public void ActivateCam(bool end)
    {
        rocketCam.GetComponent<CinemachineVirtualCamera>().enabled = true;
        Animator.SetBool("BadEnd", true);
        if (end)
        {
            Animator.SetBool("GoodEnd", true);
            Debug.Log("good end");
        }
        else
        {
            Debug.Log("bad end");
        }
    }
}
