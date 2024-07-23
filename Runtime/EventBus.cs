using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventBusSystem
{
    public static class EventBus
    {
        private static readonly Dictionary<string, EventDefinition> _eventDefinitions = new Dictionary<string, EventDefinition>();

        public static void Subscribe<T>(string EventName, Action<T> eventListener, EventListenerPriority listenerPriority = EventListenerPriority.Low) where T : IEventParameter
        {
            SubscribeEventListenerToEvent(eventListener, EventName, listenerPriority);
        }
        public static void Subscribe(string eventName, Action eventListener, EventListenerPriority listenerPriority = EventListenerPriority.Low)
        {
            SubscribeEventListenerToEvent(eventListener, eventName, listenerPriority);
        }

        private static void SubscribeEventListenerToEvent(Delegate eventListener, string eventName, EventListenerPriority listenerPriority)
        {
            if (_eventDefinitions.TryGetValue(eventName, out EventDefinition eventDefinition))
            {
                eventDefinition.AddListener(eventListener, listenerPriority);
                return;
            }

            _eventDefinitions.Add(eventName, new EventDefinition.Builder().WithDelegate(eventListener, listenerPriority).Build());
        }

        public static void Unsubscribe<T>(Action<T> listenerToRemove, string eventName) where T : IEventParameter
        {
            UnsubscribeListenerFromEvent(listenerToRemove, eventName);
        }
        public static void Unsubscribe(Action listenerToRemove, string eventName)
        {
            UnsubscribeListenerFromEvent(listenerToRemove, eventName);
        }

        private static void UnsubscribeListenerFromEvent(Delegate listenerToRemove, string eventName)
        {
            if (!_eventDefinitions.ContainsKey(eventName))
                return;

            _eventDefinitions[eventName].RemoveListener(listenerToRemove);
        }

        public static void Invoke(string eventName, IEventParameter eventParam = null)
        {
            if (_eventDefinitions.TryGetValue(eventName, out EventDefinition eventDefinition) is false)
            {
                Debug.LogWarning($"Invoking {eventName} Event Without Any Listeners To This Event");
                return;
            }

            eventDefinition.Invoke(eventParam);
        }
    }
}

