using UnityEngine;

namespace ReactionGames.TestTask.Utils
{
    public static class GameObjectUtils
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            return component != null ? component : gameObject.AddComponent<T>();
        }

        public static T GetOrAddComponent<T>(this Component thisComponent) where T : Component
        {
            var component = thisComponent.gameObject.GetComponent<T>();
            return component != null ? component : thisComponent.gameObject.AddComponent<T>();
        }

        public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T component) where T : Component
        {
            component = gameObject.GetComponentInParent<T>();
            return component != null;
        }
    }
}