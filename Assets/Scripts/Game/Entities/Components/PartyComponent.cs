using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class PartyComponent : BaseEntityComponent
    {
        [SerializeField] private Party _party;

        public Party Party
        {
            get => _party;
            set => _party = value;
        }
    }
}