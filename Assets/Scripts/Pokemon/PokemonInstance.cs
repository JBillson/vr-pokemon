using System;
using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Pokemon
{
    public class PokemonInstance : MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public Slider healthSlider;
        public TextMeshProUGUI sliderText;
        public float speed = 25f;

        private int _currentHealth;
        private int _maxHealth;
        private Pokemon _pokemon;
        private Coroutine _healthSliderCoroutine;
        private Image _healthBarImage;

        private void InitReferences()
        {
            _healthBarImage = healthSlider.fillRect.GetComponent<Image>();
        }

        public void Init(Pokemon pokemon)
        {
            InitReferences();
            _pokemon = pokemon;
            name = $"[{_pokemon.name}]";
            nameText.text = _pokemon.name;

            _maxHealth = _pokemon.stats[0].base_stat;
            _currentHealth = _maxHealth;

            healthSlider.maxValue = _maxHealth;
            healthSlider.value = _currentHealth;
            UpdateHealthBar();
        }

        [Button(ButtonStyle.FoldoutButton)]
        public void TakeDamage(int damageAmount)
        {
#if UNITY_EDITOR
            if (damageAmount == 0)
                damageAmount = Random.Range(1, _maxHealth);
#endif

            var targetHealth = _currentHealth - damageAmount;
            if (targetHealth <= 0)
                targetHealth = 0;
            if (targetHealth >= _maxHealth)
                targetHealth = _maxHealth;

            if (_healthSliderCoroutine != null)
                StopCoroutine(_healthSliderCoroutine);

            _healthSliderCoroutine = StartCoroutine(AnimateHealthSlider(targetHealth));
        }

        private IEnumerator AnimateHealthSlider(int targetHealth)
        {
            while (Math.Abs(healthSlider.value - targetHealth) > 0.1f)
            {
                if (healthSlider.value < targetHealth)
                    healthSlider.value += speed * Time.deltaTime;
                else
                    healthSlider.value -= speed * Time.deltaTime;

                UpdateHealthBar();
                yield return null;
            }

            _currentHealth = targetHealth;
            healthSlider.value = _currentHealth;
            UpdateHealthBar();

            if (healthSlider.value <= 0)
                Fainted();
        }

        private void UpdateHealthBar()
        {
            if (healthSlider.value <= healthSlider.maxValue * 0.2)
                _healthBarImage.color = Color.red;
            else if (healthSlider.value <= healthSlider.maxValue * 0.5)
                _healthBarImage.color = Color.yellow;
            else
                _healthBarImage.color = Color.green;

            sliderText.text = $"{(int)healthSlider.value}/{healthSlider.maxValue}";
        }

        private void Fainted()
        {
            Debug.Log($"[{_pokemon.name}] fainted!");
            Destroy(gameObject);
        }
    }
}