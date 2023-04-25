using UnityEngine;
using UnityEngine.EventSystems;

public class Cables_Black3 : MonoBehaviour, IPointerClickHandler
{

    public bool isPacked = true;
    public bool isBroken = false;

    public Animation anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked)
        {
            anim.Play("KabBlack3");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else
        {
            anim.Play("KabBlack3R");
            Debug.Log(gameObject.name);
            isPacked = true;
        }
    }

    public void breakWire()
    {
        isBroken = true;
    }

    public void fixWire()
    {
        isBroken = false;
    }
}
