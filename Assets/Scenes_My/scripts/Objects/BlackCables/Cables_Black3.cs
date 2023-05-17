using UnityEngine;
using UnityEngine.EventSystems;

public class Cables_Black3 : MonoBehaviour, IPointerClickHandler
{

    public bool isPacked = true;
    public bool isBroken = false;
    public GameObject CutBtn;

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

    public void Wire()
    {
        isBroken = !isBroken;
        if (isBroken)
        {
            CutBtn.transform.Rotate(0, 0, 90f);
        }
        else
        {
            CutBtn.transform.Rotate(0, 0, -90f);
        }
        Debug.Log("������ " + this.name + " ���������: " + isBroken);
    }

    private void Awake()
    {
        CutBtn = GameObject.Find("Cut3");
    }
}