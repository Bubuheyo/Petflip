using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UISwitcher : MonoBehaviour
{
    [System.Serializable]
    public class ButtonAction
    {
        public string buttonName = "Continue";
   
        public GameObject Openmenu;
      
        public bool closeMenu = true;
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

            }
            var a = action;
            button.clicked += () =>
            {
                if (a.Openmenu!= null) a.Openmenu.SetActive(true);
                if (a.closeMenu) gameObject.SetActive(false);
            };
        }
    }
}
