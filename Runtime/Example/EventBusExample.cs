using UnityEngine;

namespace EventBusSystem.Example
{
    public class EventBusExample : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpaceKeyDown();
            if (Input.GetKeyDown(KeyCode.Backspace))
                BackspaceDown();
        }

        private void BackspaceDown()
        {
            EventBus.Invoke(EventDirectory.TestButton);
        }

        private void SpaceKeyDown()
        {
            EventBus.Invoke(EventDirectory.TestButton_testparam,
                new EventParameter<string>() { value = "SPACE KEY DOWN!" });
        }
    }
}


