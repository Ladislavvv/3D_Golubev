using UnityEngine;
using UnityEngine.EventSystems;

public class klemmnik : MonoBehaviour, IPointerClickHandler
{

    public GameObject KlemmnikObj;
    public GameObject Vints;

    bool isPacked = true;

    private Animator anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked)
        {
            //anim.Rebind();
            anim.SetFloat("Reverse", 1);
            anim.Play("Klemmnik");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else
        {
            anim.SetFloat("Reverse", -1);
            anim.Play("Klemmnik");
            //anim.Rebind();
            Debug.Log(gameObject.name);
            isPacked = true;
        }
    }
 
    void Start()
    {
        anim = GetComponent<Animator>();
    }
}
