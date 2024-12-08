using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    [RequireComponent(typeof(Entity))]
    public abstract class BaseEntityComponent : MonoBehaviour
    {
        private Entity _entity;

        public Entity Entity => _entity != null ? _entity : (_entity = GetComponent<Entity>());
    }
}