using ReactionGames.TestTask.Game.Entities;
using ReactionGames.TestTask.Game.Entities.Components;
using UnityEngine;
using UnityEngine.UI;

namespace ReactionGames.TestTask.Game
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private Slider _healthBar;

        private void Update()
        {
            bool playerExist = false;
            foreach (var (playerInput, health) in EntityManager.Instance.FilterComponents<PlayerInputComponent, HealthComponent>())
            {
                _healthBar.value = health.Health / health.MaxHealth;
                playerExist = true;
                break;
            }

            _healthBar.gameObject.SetActive(playerExist);
        }
    }
}