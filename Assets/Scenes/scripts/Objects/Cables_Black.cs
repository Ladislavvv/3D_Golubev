using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cables_Black : MonoBehaviour, IPointerClickHandler
{

    bool isPacked = true;

    private Animator anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked)
        {
            //anim.Rebind();
            gameObject.GetComponent<Animator>().SetFloat("Reverse", 1);
            anim.Play("Cables_Main");
            Debug.Log(gameObject.name);

            isPacked = false;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetFloat("Reverse", -1);
            anim.Play("Cables_Main");
            Debug.Log(gameObject.name);
            isPacked = true;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }
}
