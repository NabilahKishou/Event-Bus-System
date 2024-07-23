using UnityEngine;

namespace EventBusSystem.Example
{
    public class EventBusListener : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.Subscribe(EventDirectory.TestButton,  ClickButton);
            EventBus.Subscribe<EventParameter<string>>(EventDirectory.TestButton_testparam, (param) => ClickParametered(param.value));
        }

        private void ClickButton()
        {
            Debug.Log("CLICKING THE TEST BUTTON");
        }
        private void ClickParametered(string value)
        {
            Debug.Log($"CLICKING THE TEST BUTTON WITH PARAMETER: {value}");
        }
    }
}


