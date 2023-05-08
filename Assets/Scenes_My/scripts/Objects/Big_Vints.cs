using UnityEngine;
using UnityEngine.EventSystems;

public class Big_Vints : MonoBehaviour, IPointerClickHandler
{
    public bool isPacked = true;

    public Front_Box FrontBox;

    public Animation anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked && FrontBox.isPacked)
        {
            anim.Play("BigVints");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else if(!isPacked && FrontBox.isPacked)
        {
            anim.Play("BigVintsR");
            Debug.Log(gameObject.name);
            isPacked = true;
        }
        else
        {
            Debug.Log("Error: Крышка открыта!");
        }
    }
}
