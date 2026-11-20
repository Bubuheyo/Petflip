using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class CloseUI : MonoBehaviour
{
    public string buttonName = "Close";

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var button = root.Q<Button>(buttonName);

        if (button != null)
            button.clicked += () => gameObject.SetActive(false);
    }
}
