using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public Animator animator;
    
    public GameObject ui_imgtext;
    public GameObject ui_obj;
    // Start is called before the first frame update


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ui_obj.SetActive(true);
        ui_imgtext.SetActive(true);
            animator.SetBool("Hide",false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("Hide", true);
            ui_imgtext.SetActive(false);
        }
    }
}
