using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UISwitcher : MonoBehaviour
{
    [System.Serializable]
    public class ButtonAction
    {
        [Tooltip("The button's Name from UI Builder (e.g. Continue)")]
        public string buttonName = "Continue";

        [Tooltip("The UI to open when this button is clicked (can be left empty)")]
        public GameObject menuToOpen;

        [Tooltip("Close this UI when the button is clicked?")]
        public bool closeThisMenu = true;
    }

    public List<ButtonAction> buttons = new List<ButtonAction>();

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        foreach (var action in buttons)
        {
            var button = root.Q<Button>(action.buttonName);
            if (button == null)
            {
                Debug.LogWarning($"Button \"{action.buttonName}\" not found in {gameObject.name}");
                continue;
            }

            var a = action; // copy for the click handler
            button.clicked += () =>
            {
                if (a.menuToOpen != null) a.menuToOpen.SetActive(true);
                if (a.closeThisMenu) gameObject.SetActive(false);
            };
        }
    }
}
