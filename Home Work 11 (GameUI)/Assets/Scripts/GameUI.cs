using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _continueButton;

    private string _name;
    public float maxHealth = 10f;
    private float _currentHealth;

    private void Start()
    {
        _menu.SetActive(true);
        
        _currentHealth = maxHealth;
        
        _healthBar.fillAmount = 1f;
        _healthBarSlider.value = 10f;
    }

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(OnMenuClick);
        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        _inputField.onValueChanged.AddListener(OnInputChanged);
        _damageButton.onClick.AddListener(TakeDamage);
        _quitButton.onClick.AddListener(OnQuit);
        _continueButton.onClick.AddListener(OnContinue);    
    }


    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(OnMenuClick);
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }

    private void OnMenuClick()
    {
        _menu.SetActive(!_menu.activeSelf);
    }

    private void OnContinue()
    {
        _menu.SetActive(false);
    }

    private void OnQuit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void OnVolumeChanged(float volume)
    {
        Debug.Log($"Volume: {volume}");
    }

    private void OnInputChanged(string text)
    {
        _name = _inputField.text;
        Debug.Log($"Player: {_name}");
    }

    private void TakeDamage()
    {
        _currentHealth -= 1;
        
        if (_currentHealth < 0f)
            _currentHealth = 0f;
        
        _healthBarSlider.value = _currentHealth;
        _healthBar.fillAmount = _currentHealth / maxHealth;

        Debug.Log($"Player {_name} has taken damage. HP left: {_currentHealth}");
    }
}