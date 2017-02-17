using Wild.InterfacesMB;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace Wild.UI.ScreenManagement.Data
{
    public class ScreenData : MonoBehaviour, IOnValidate, IAwake
    {
        private Dictionary<UIContainerTag, UIContainer> _uiContainers = new Dictionary<UIContainerTag, UIContainer>();

        [SerializeField]
        private List<UIContainerData> _uiContainerDatas = new List<UIContainerData>();

        public void OnValidate()
        {
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

        public void Awake()
        {
            foreach (var item in _uiContainerDatas)
            {
                _uiContainers.Add(item.ContainerTag, item.Container);
            }
        }

        //[SerializeField]
        //private List<UIContainer> _uiContainers = new List<UIContainer>();

        //public void OnValidate()
        //{
        //    _uiContainers.Clear();
        //    _uiContainers = GetComponentsInChildren<UIContainer>(true).ToList();
        //}

        //public UIContainer GetUIContainer(int id)
        //{
        //    if (id > _uiContainers.Count - 1)
        //        return null;

        //    return _uiContainers[id];
        //}

        //public RectTransform GetUIContainerRectTransform(int id)
        //{
        //    return GetUIContainer(id).rectTransform;
        //}
    }
}
