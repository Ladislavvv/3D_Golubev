using UnityEngine;
using UnityEngine.EventSystems;

public class klemmnik : MonoBehaviour, IPointerClickHandler
{

    public GameObject KlemmnikObj;
    public GameObject Vints;
    // public GameObject Klemmnik_Center1;
    // public GameObject Klemmnik_Center2;
    // public GameObject Klemmnik_Center3;
    // public GameObject Klemmnik_Center4;
    // public GameObject Klemmnik_Center5;

    // public GameObject Klemmnik_Left;
    // public GameObject Klemmnik_Right;

    // public GameObject Klemmnik_Vint1;
    // public GameObject Klemmnik_Vint2;

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     if(eventData.pointerId == -1)
    //     {
    //        Debug.Log("Click");
    //     }

    //     // if (eventData.pointerPress != null)
    //     // {
    //     //     GameObject clickedObject = eventData.pointerPress.gameObject;
    //     //     // Debug.Log("Object Nme: " + clickedObject.name);
    //     //     if (clickedObject.transform.IsChildOf(transform))
    //     //     {
    //     //         // The clicked object is a child of this parent object
    //     //         Debug.Log("Clicked on child object: " + clickedObject.name);
    //     //     }
    //     // }

    //     //if( Planka.gameObject.name)

    // }

    private Animator anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        anim.Rebind();
        anim.Play("CubeAnimation");
    }
 
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
