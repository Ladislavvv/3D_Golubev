using UnityEngine;
using UnityEngine.EventSystems;

public class Cables_Black : MonoBehaviour, IPointerClickHandler
{

    public bool isPacked = true;

    public Animation anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked)
        {
            anim.Play("KabBlack");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else
        {
            anim.Play("KabBlackR");
            Debug.Log(gameObject.name);
            isPacked = true;
        }
    }
}
