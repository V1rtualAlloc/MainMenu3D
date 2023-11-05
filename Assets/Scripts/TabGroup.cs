using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons = new List<TabButton>();
    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;    
    public Color textIdle;
    public Color textHover;
    public Color textActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap = new List<GameObject>();

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHover;
            button.textMesh.color = textHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.color = tabActive;
        button.textMesh.color = textActive;
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) 
            {
                button.ActivatePanel();
                continue; 
            }
            button.background.color = tabIdle;
            button.textMesh.color = textIdle;
            button.DeactivatePanel();
        }
    }

    public void Start()
    {
        OnTabSelected(selectedTab);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedTab.transform.GetSiblingIndex() > 0)
            {
                OnTabSelected(tabButtons[(selectedTab.transform.GetSiblingIndex() - 1) % tabButtons.Count]);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedTab.transform.GetSiblingIndex() < (transform.childCount - 1))
            {
                OnTabSelected(tabButtons[(selectedTab.transform.GetSiblingIndex() + 1) % tabButtons.Count]);
            }
        }
    }
}
