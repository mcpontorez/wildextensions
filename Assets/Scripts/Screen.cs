using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WildUI.UIComponents;
using WildUI.UIComponents.Management;

public class Screen : MonoBehaviour
{
	public void Init()
    {
        gameObject.name = "Screen";
        Canvas canvas = Instantiate(UIComponentManager.Components.canvas);
        canvas.transform.SetParent(transform);

        ButtonController button = Instantiate(UIComponentManager.Components.button);
        button.rectTransform.SetParent(canvas.transform);
        button.rectTransform.anchorMin = new Vector2(0.1f, 0.1f);
        button.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        button.Text = "69 рублей";
        button.OnClick += () => Debug.Log("нагетсы");
    }
}
