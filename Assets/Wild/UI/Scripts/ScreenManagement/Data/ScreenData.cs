using Wild.InterfacesMB;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wild.UI.Components.Canvases;

namespace Wild.UI.ScreenManagement.Data
{
    public class ScreenData : MonoBehaviour, IOnValidate, IAwake
    {
        [SerializeField]
        private ScreenBehaviourBase _screenBehaviour;
        public ScreenBehaviourBase ScreenBehaviour => _screenBehaviour;

        [SerializeField]
        private CanvasController _canvas;
        public ICanvasController CanvasController { get { return _canvas; } }

        private Dictionary<UIContainerTag, UIContainer> _uiContainers = new Dictionary<UIContainerTag, UIContainer>();

        [SerializeField]
        private List<UIContainerData> _uiContainerDatas = new List<UIContainerData>();

        public void OnValidate()
        {
            _canvas = GetComponentInChildren<CanvasController>();

            Dictionary<UIContainerTag, UIContainer> uiContainers = new Dictionary<UIContainerTag, UIContainer>();

            foreach (var item in _uiContainerDatas)
            {
                uiContainers.Add(item.ContainerTag, item.Container);
            }

            List<UIContainer> containers = GetComponentsInChildren<UIContainer>(true).ToList();

            for (int i = containers.Count - 1; i >= 0; i--)
            {
                if (uiContainers.ContainsValue(containers[i]))
                    containers.RemoveAt(i);
                else
                {
                    if (uiContainers.Count >= 100)
                    {
                        Debug.LogWarning("Превышено количество тегов: нажмите RemoveEmptyTags или пересмотрите архитектуру Screen");
                        return;
                    }
                    for (int j = 0; j < 100; j++)
                    {
                        if (!uiContainers.ContainsKey((UIContainerTag)j))
                        {
                            uiContainers.Add((UIContainerTag)j, containers[i]);
                            break;
                        }
                    }
                }
            }

            List<UIContainerData> containerDatas = new List<UIContainerData>();
            foreach (var item in uiContainers)
            {
                if (!item.Value)
                    continue;

                containerDatas.Add(new UIContainerData(item.Key, item.Value));
            }

            _uiContainerDatas = containerDatas;
        }

        [ContextMenu("Remove Empty Tags")]
        public void RemoveEmptyTags()
        {
            for (int i = _uiContainerDatas.Count - 1; i >= 0; i--)
            {
                if (!_uiContainerDatas[i].Container)
                    _uiContainerDatas.RemoveAt(i);
            }
        }

        public UIContainer GetUIContainer(UIContainerTag containerTag)
        {
            if (!_uiContainers.ContainsKey(containerTag))
                return null;
            return _uiContainers[containerTag];
        }

        public TComponent GetComponentInContainer<TComponent>(UIContainerTag containerTag) => 
            GetUIContainer(containerTag).GetComponent<TComponent>();

        public void Awake()
        {
            foreach (var item in _uiContainerDatas)
            {
                _uiContainers.Add(item.ContainerTag, item.Container);
            }
        }
    }
}
