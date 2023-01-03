using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGroup : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();

    public TabGroup tabGroup;

    public int panelIndex;

    public void Awake()
    {
        
    }

    void ShowCurrentPanel()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if (i == panelIndex)
            {
                panels[i].gameObject.SetActive(true);
            }
            else
            { 
                panels[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetPageIndex(int index)
    {
        panelIndex = index;
        ShowCurrentPanel();
    }
}
