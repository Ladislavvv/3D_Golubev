using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Graduirovka : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Button HK;
    public UnityEngine.UI.Button HA;
    public UnityEngine.UI.Button PP;
    public float alpha;

    void Start()
    {
        HK.onClick.AddListener(OnClickHK);
        HA.onClick.AddListener(OnClickHA);
        PP.onClick.AddListener(OnClickPP);
    }

    void OnClickHK()
    {
        alpha = 26f;
        HK.interactable = false;
        HA.interactable = true;
        PP.interactable = true;
    }

    void OnClickHA()
    {
        alpha = 41f;
        HA.interactable = false;
        HK.interactable = true;
        PP.interactable = true;
    }

    void OnClickPP()
    {
        alpha = 7.9f;
        PP.interactable = false;
        HK.interactable = true;
        HA.interactable = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
