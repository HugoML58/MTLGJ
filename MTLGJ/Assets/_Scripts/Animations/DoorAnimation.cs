using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour, Interactable
{
    Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
        Animator.SetBool("Activate", false);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.K))
        // {
        //     // Animator.Play("DoorAnimation");
        // }
    }

    public void Interact()
    {
        bool state = Animator.GetBool("Activate");
        Debug.Log(state);
        Animator.SetBool("Activate", !state);
    }
}
