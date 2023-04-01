using UnityEngine;
using UnityEngine.EventSystems;

public class Korpus2 : MonoBehaviour, IPointerClickHandler
{

    public bool isPacked = true;

    public Cables_Black cables_black;
    public Cables_Red CabeliBigRed;
    public Planka Planka;

    public Animation anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked && !cables_black.isPacked && !CabeliBigRed.isPacked)
        {
            anim.Play("Korpus2");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else if(!isPacked && !cables_black.isPacked && !CabeliBigRed.isPacked && Planka.isPacked)
        {
            anim.Play("Korpus2R");
            Debug.Log(gameObject.name);
            isPacked = true;
        }
        else
        {
            Debug.Log("Error: ������� �� �����������!");
        }
    }
}
