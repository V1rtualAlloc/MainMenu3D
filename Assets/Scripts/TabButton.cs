using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public GameObject panel;

    public Image background;
    public TextMeshProUGUI textMesh;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
        panel?.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
        panel?.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
