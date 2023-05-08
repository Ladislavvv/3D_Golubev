using UnityEngine;
using UnityEngine.EventSystems;

public class Cables_Red : MonoBehaviour, IPointerClickHandler
{
    public bool isPacked = true;

    public Animation anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked)
        {
            anim.Play("CabRed");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else
        {
            anim.Play("CabRedR");
            Debug.Log(gameObject.name);
            isPacked = true;
        }
    }
}
