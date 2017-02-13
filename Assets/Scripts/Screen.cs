using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WildUI.UIComponents;
using WildUI.UIComponents.Management;
using WildUI.UIHelpers;

public class Screen : MonoBehaviour
{
	public void Init()
    {
        gameObject.name = "Screen";
        Canvas canvas = Instantiate(UIComponentManager.Components.canvas);
        canvas.transform.SetParent(transform);

        ButtonController button = Instantiate(UIComponentManager.Components.button);
        button.rectTransform.SetParent(canvas.transform);
        button.rectTransform.SetAnchors(new Vector2(0.1f, 0.1f), new Vector2(0.5f, 0.5f));
        button.Text = "69 рублей";
        button.OnClick += () => Debug.Log("нагетсы");
    }
}
