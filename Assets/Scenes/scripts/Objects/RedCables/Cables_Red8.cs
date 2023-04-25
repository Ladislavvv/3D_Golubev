using UnityEngine;
using UnityEngine.EventSystems;

public class Cables_Red8 : MonoBehaviour, IPointerClickHandler
{
    public bool isPacked = true;
    public bool isBroken = false;

    public Animation anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked)
        {
            anim.Play("CabRed8");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else
        {
            anim.Play("CabRed8R");
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