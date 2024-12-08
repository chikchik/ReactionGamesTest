using ReactionGames.TestTask.Game.Entities.Components;
using System.Collections.Generic;
using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities
{
    public class EntityManager : MonoBehaviour
    {
        private static EntityManager _instance;

        public static EntityManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<EntityManager>();
                }

                if (_instance == null)
                {
                    _instance = new GameObject("Entities").AddComponent<EntityManager>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        public Entity CreateEntity(Entity prefab) => Object.Instantiate(prefab, transform, false);

        public void DestroyEntity(Entity entity) => Object.Destroy(entity.gameObject);

        public IEnumerable<Entity> GetEntities() => GetComponentsInChildren<Entity>();

        public IEnumerable<T1> FilterComponents<T1>()
            where T1 : BaseEntityComponent
        {
            return GetComponentsInChildren<T1>();
        }

        public IEnumerable<(T1, T2)> FilterComponents<T1, T2>()
            where T1 : BaseEntityComponent
            where T2 : BaseEntityComponent
        {
            foreach (var c1 in GetComponentsInChildren<T1>())
            {
                if (c1.TryGetComponent(out T2 c2))
                    yield return (c1, c2);
            }
        }
    }
}