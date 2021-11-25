﻿using SamrStudio.Core.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

namespace SamrStudio.Core.Events
{
    /// <summary>
    /// This class is used for scene-loading events.
    /// Takes a GameSceneSO of the location or menu that needs to be loaded, and a bool to specify if a loading screen needs to display.
    /// </summary>
    [CreateAssetMenu(menuName = "SamrStudio/Events/Load Event")]
    public class LoadEventSO : ScriptableObject
    {
        public UnityAction<GameSceneSO, bool, bool> OnLoadingRequested;

        [SerializeField]
        [TextArea]
        private string description;

        public void RaiseEvent(GameSceneSO locationToLoad, bool showLoadingScreen = false, bool fadeScreen = false)
        {
            if (OnLoadingRequested != null)
            {
                OnLoadingRequested.Invoke(locationToLoad, showLoadingScreen, fadeScreen);
            }
            else
            {
                Debug.LogWarning("A Scene loading was requested, but nobody picked it up. " +
                    "Check why there is no SceneLoader already present, " +
                    "and make sure it's listening on this Load Event channel.");
            }
        }
    }
}
