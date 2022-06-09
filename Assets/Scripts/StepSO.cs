using UnityEngine;

[CreateAssetMenu(fileName = "Olololo", menuName = "Configs/Step")]
public class StepSO : ScriptableObject
{
    public string DebugHeaderText;
    
    [TextArea(4, 8)] 
    public string DescriptionText;
    
    [TextArea(4, 6)] 
    public string ChoicesText;

    public StepSO[] Choices;
}