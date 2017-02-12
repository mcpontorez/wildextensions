using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WildUI.UIComponentsManagement;

public class Screen : MonoBehaviour
{
	public void Init()
    {
        gameObject.name = "Screen";
        Canvas canvas = Instantiate(UIComponentManager.Components.canvas);
        canvas.transform.SetParent(transform);

        Button button = Instantiate(UIComponentManager.Components.button);
        button.transform.SetParent(canvas.transform);
    }
}
