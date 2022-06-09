using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _headerLabel;
    [SerializeField] private TextMeshProUGUI _descriptionLabel;
    [SerializeField] private TextMeshProUGUI _choicesLabel;
    [SerializeField] private Button _menuButton;

    [Header("Initial Setup")]
    [SerializeField] private StepSO _startStep;

    [Header("External Components")]
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private string _menuSceneName;
    [SerializeField] private string _gameOverSceneName;

    private StepSO _currentStep;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _menuButton.onClick.AddListener(MenuButtonClicked);
        SetCurrentStep(_startStep);
    }

    public void Test()
    {
        MenuScreen.Instance.Test();
    }

    private void FirstButtonClicked()
    {
        SetCurrentStep(0);
    }

    private void Update()
    {
        CheckGameOver();

        int choiceIndex = GetPressedButtonIndex();

        if (!IsIndexValid(choiceIndex))
            return;

        SetCurrentStep(choiceIndex);
    }

    #endregion


    #region Private methods

    private void CheckGameOver()
    {
        if (!Input.GetKeyDown(KeyCode.Return))
            return;

        if (_currentStep.Choices.Length == 0)
            _sceneLoader.LoadScene(_gameOverSceneName);
    }

    private bool IsIndexValid(int choiceIndex) =>
        choiceIndex >= 0;

    private int GetPressedButtonIndex()
    {
        int pressedButtonIndex = NumButtonHelper.GetPressedButtonIndex();
        return pressedButtonIndex - 1;
    }

    private void SetCurrentStep(int choiceIndex)
    {
        if (_currentStep.Choices.Length <= choiceIndex)
            return;

        StepSO nextStep = _currentStep.Choices[choiceIndex];
        SetCurrentStep(nextStep);
    }

    private void SetCurrentStep(StepSO step)
    {
        if (step == null)
            return;

        _currentStep = step;

        _headerLabel.text = _currentStep.DebugHeaderText;
        _descriptionLabel.text = _currentStep.DescriptionText;
        _choicesLabel.text = _currentStep.ChoicesText;
    }

    private void MenuButtonClicked() =>
        _sceneLoader.LoadScene(_menuSceneName);

    #endregion
}