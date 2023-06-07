using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonInstance : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Slider healthSlider;
    public TextMeshProUGUI sliderText;

    private int _currentHealth;
    private int _maxHealth;
    private Pokemon _pokemon;
    private Coroutine _healthSliderCoroutine;
    private Image _healthBarImage;

    public void Init(Pokemon pokemon)
    {
        _pokemon = pokemon;

        _healthBarImage = healthSlider.fillRect.GetComponent<Image>();

        _maxHealth = _pokemon.stats[0].base_stat;
        _currentHealth = _maxHealth;

        nameText.text = _pokemon.name;
        healthSlider.maxValue = _maxHealth;
        healthSlider.value = _currentHealth;

        UpdateHealthBar();
    }

    [Button]
    public void TakeDamage(int damage)
    {
        var targetHealth = _currentHealth -= damage;
        if (_healthSliderCoroutine != null)
            StopCoroutine(_healthSliderCoroutine);

        _healthSliderCoroutine = StartCoroutine(AnimateHealthSlider(targetHealth));

        while (_healthSliderCoroutine != null)
        {
        }

        if (healthSlider.value <= 0)
        {
            Fainted();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthSlider.value <= healthSlider.maxValue * 0.2)
            _healthBarImage.color = Color.red;
        else if (healthSlider.value <= healthSlider.maxValue * 0.5)
            _healthBarImage.color = Color.yellow;
        else
            _healthBarImage.color = Color.green;

        sliderText.text = $"{_currentHealth}/{_maxHealth}";
    }

    private IEnumerator AnimateHealthSlider(int targetHealth)
    {
        var speed = 2f;
        var startHealth = healthSlider.value;

        var timeScale = 0f;
        while (timeScale < 1 && healthSlider.value > 0)
        {
            timeScale += Time.deltaTime * speed;
            healthSlider.value = Mathf.Lerp(startHealth, targetHealth, timeScale);
            UpdateHealthBar();
        }

        return null;
    }

    private void Fainted()
    {
        Debug.Log($"[{_pokemon.name}] fainted!");
        Destroy(gameObject);
    }
}