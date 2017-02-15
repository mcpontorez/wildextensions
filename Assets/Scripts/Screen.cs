using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WildUI.ScreenManagement.Data;
using WildUI.UIComponents;
using WildUI.UIComponents.Management;
using WildUI.UIHelpers;

public class Screen : MonoBehaviour
{
	public void Init()
    {
        gameObject.name = "Screen";
        ScreenData data = Resources.Load<ScreenData>("Screen");
        data = InstantiateAndAdopt(data, transform);

        ButtonController button = InstantiateAndAdopt(UIComponentManager.Components.button, data.GetUIContainerRectTransform(UIContainerTag.Tag1));
        button.Text = "играть";
        button.OnClick += () => Debug.Log("играю");

        //gameObject.name = "Screen";
        //CanvasController canvas = Instantiate(UIComponentManager.Components.canvas);
        //canvas.rectTransform.SetParent(transform);

        //RectTransform contentPanel = Instantiate(UIComponentManager.Components.panel);
        //contentPanel.SetParent(canvas.RootLayout);
        //contentPanel.SetOffsets(new Vector2(10f, 10f), new Vector2(-10f, -10f));

        //ButtonController button = InstantiateAndAdopt(UIComponentManager.Components.button, contentPanel);

        //button.rectTransform.SetAnchors(new Vector2(0.1f, 0.1f), new Vector2(0.5f, 0.5f));
        //button.Text = "69 рублей";
        //button.OnClick += () => Debug.Log("нагетсы");
    }

    public T1 InstantiateAndAdopt<T1, T2>(T1 objectToAdopt, T2 parent) where T1 : Component where T2 : Transform
    {
        objectToAdopt = Instantiate(objectToAdopt);
        objectToAdopt.transform.SetParent(parent);
        return objectToAdopt;
    }
}
