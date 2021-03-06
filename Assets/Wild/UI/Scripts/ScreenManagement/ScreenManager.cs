﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using Wild.Generics;
using Wild.Systems.Management;

namespace Wild.UI.ScreenManagement
{
    public class ScreenManager : IScreenManager
    {
        public ScreenManager()
        {
            GameObject sm = new GameObject("ScreenManager");
            Container = sm.AddComponent<ScreenManagerContainer>();

            SystemManager = new SystemManager(Container.SystemsContainer);
        }

        public ScreenManagerContainer Container { get; private set; }

        public EventSystem EventSystem { get; set; }

        public SystemManager SystemManager { get; private set; }

        private Dictionary<Type, IScreen> _screens = new Dictionary<Type, IScreen>();

        public TScreen GetScreen<TScreen>() where TScreen : IScreen, new()
        {
            Type screenType = typeof(TScreen);

            TScreen screen;

            if (!_screens.ContainsKey(screenType))
            {
                screen = new TScreen() { ScreenManager = this };
                _screens.Add(screenType, screen);
                screen.Data.transform.SetParent(Container.ScreensContainer);
                screen.Init();
            }
            else
                screen = (TScreen)_screens[screenType];
            return screen;
        }

        public TScreen ShowScreen<TScreen>(int? sortOrder = null) where TScreen : IScreen, new()
        {
            TScreen screen = GetScreen<TScreen>();

            if (sortOrder != null)
                screen.Data.CanvasController.Canvas.sortingOrder = (int)sortOrder;

            screen.Show();

            return screen;
        }

        public TScreen ShowScreen<TScreen>(IGenericNewTypeContainer<TScreen> screenTypeContainer, int? sortOrder = null) where TScreen : IScreen
        {
            Type screenType = screenTypeContainer.GetGenericType();

            TScreen screen;

            if (!_screens.ContainsKey(screenType))
            {
                screen = (TScreen)Activator.CreateInstance(screenType);
                screen.ScreenManager = this;
                _screens.Add(screenType, screen);
                screen.Data.transform.SetParent(Container.ScreensContainer);
                screen.Init();
            }
            else
                screen = (TScreen)_screens[screenType];

            if (sortOrder != null)
                screen.Data.CanvasController.Canvas.sortingOrder = (int)sortOrder;

            screen.Show();

            return screen;
        }

        public void HideScreen<TScreen>() where TScreen: IScreen
        {
            Type screenType = typeof(TScreen);

            if (_screens.ContainsKey(screenType))
                _screens[screenType].Hide();
        }

        public void HideAllScreens()
        {
            foreach (var screen in _screens.Values)
            {
                screen.Hide();
            }
        }

        public void DestroyScreen<TScreen>() where TScreen : IScreen
        {
            System.Type screenType = typeof(TScreen);

            if (!_screens.ContainsKey(screenType))
                return;

            _screens[screenType].Destroy();
            _screens.Remove(screenType);
        }

        public void DestroyScreens<TScreenBase>() where TScreenBase : IScreen
        {

            Type screenBaseType = typeof(TScreenBase);
            List<Type> screenTypes = _screens.Keys.Where(k => screenBaseType.GetTypeInfo().IsAssignableFrom(k.GetTypeInfo())).ToList();
            foreach (var screenType in screenTypes)
            {
                _screens[screenType].Destroy();
                _screens.Remove(screenType);
            }
        }
    }
}
