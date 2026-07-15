using TMPro;
using UnityEngine;

public class LoadingPanel : UIPanel
{
    public TextMeshProUGUI progressText;
    
    public void SetProgress(float progressValue)
    {
        float progress = progressValue * 100;
        string progressString = "Progress Ratio : " + progress.ToString();
        progressText.SetText(progressString);
    }
}
