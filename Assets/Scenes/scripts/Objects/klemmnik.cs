using UnityEngine;
using UnityEngine.EventSystems;

public class klemmnik : MonoBehaviour, IPointerClickHandler
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
            anim.Play("Klemmnik");
            Debug.Log(gameObject.name);
            isPacked = false;
            Debug.Log(isPacked);
        }
        else if(!isPacked && !cables_black.isPacked && !CabeliBigRed.isPacked && Planka.isPacked)
        {
            anim.Play("KlemmnikR");
            Debug.Log(gameObject.name);
            isPacked = true;
            Debug.Log(isPacked);
        }
        else
        {
            Debug.Log("Error: Провода не отсоединены!");
        }
    }
}
