using UnityEngine;
using UnityEngine.EventSystems;

public class Cables_Red5 : MonoBehaviour, IPointerClickHandler
{
    public bool isPacked = true;
    public bool isBroken = false;

    public Animation anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked)
        {
            anim.Play("CabRed5");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else
        {
            anim.Play("CabRed5R");
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
