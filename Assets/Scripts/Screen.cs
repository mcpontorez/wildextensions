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
        data = Instantiate(data, transform, false);

        ButtonController button = Instantiate(UIComponentManager.Components.button, data.GetUIContainerRectTransform(UIContainerTag.Tag1), false);

        button.Text = "играть";
        button.OnClick += () => Debug.Log("играю");

        for (int i = 0; i < 3; i++)
        {
            button = Instantiate(UIComponentManager.Components.button, data.GetUIContainerRectTransform(UIContainerTag.Tag0), false);

            button.Text = "кнопка" + i;
            button.OnClick += () => Debug.Log("кнопка" + i);
        }

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
}
