using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Wild.ResourceUtils
{
    /// <summary>
    /// Вычисляет и хранит путь до ассета в папке Resources. Наследоваться и задать TObject для работы сериализатора Unity
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    [Serializable]
    public class ResourcePath<TObject> where TObject: UnityEngine.Object
    {

        [SerializeField, HideInInspector]
        private string _name;
        /// <summary>
        /// Имя ассета
        /// </summary>
        public string Name { get { return _name; } }
#if UNITY_EDITOR
        [SerializeField]
        private TObject _resourceObject;
#endif
        /// <summary>
        /// Узнаёт Path ассета, лежащего в Resources. Вызывать в OnValidate()
        /// </summary>
        public void Setup()
        {
#if UNITY_EDITOR
            if (_resourceObject)
            {
                _path = UnityEditor.AssetDatabase.GetAssetPath(_resourceObject);
                string startPath = "/Resources/";
                if (!string.IsNullOrEmpty(_path) && _path.Contains(startPath))
                {
                    _path = _path.Remove(0, _path.IndexOf(startPath) + startPath.Length);
                    _path = _path.Remove(_path.LastIndexOf("."));
                    _name = _resourceObject.name;
                }
                else
                {
                    Debug.LogWarning(_resourceObject.name + " must be located in Resources folder");
                    _resourceObject = null;
                }
            }
#endif
        }

        [SerializeField]
        private string _path;
        /// <summary>
        /// Путь до ассета в папке Resources
        /// </summary>
        public string Path { get { return _path; } }
    }
}
