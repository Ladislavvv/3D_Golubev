using UnityEngine;
using UnityEngine.EventSystems;

public class Front_Box : MonoBehaviour, IPointerClickHandler
{
    public bool isPacked = true;
    public Big_Vints Vints;
    public Animation anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked && !Vints.isPacked)
        {
            anim.Play("FrontBox");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else if(!isPacked && !Vints.isPacked)
        {
            anim.Play("FrontBoxR");
            Debug.Log(gameObject.name);
            isPacked = true;
        }
        else
        {
            Debug.Log("Error: Винты не откручены!");
        }
    }
}
