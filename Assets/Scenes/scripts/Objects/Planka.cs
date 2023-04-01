using UnityEngine;
using UnityEngine.EventSystems;

public class Planka : MonoBehaviour, IPointerClickHandler
{
    public bool isPacked = true;

    public Korpus1 Korpus1;
    public Korpus2 Korpus2;
    public klemmnik klemmnik;

    public Animation anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked && !Korpus1.isPacked && !Korpus2.isPacked && !klemmnik.isPacked)
        {
            anim.Play("Planka");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else if(!isPacked && !Korpus1.isPacked && !Korpus2.isPacked && !klemmnik.isPacked)
        {
            anim.Play("PlankaR");
            Debug.Log(gameObject.name);
            isPacked = true;
        }
    }
}
