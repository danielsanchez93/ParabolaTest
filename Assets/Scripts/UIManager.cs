using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager: MonoBehaviour
{
    [SerializeField] GameObject PanelAlert;
    [SerializeField] GameObject PanelData;
    [SerializeField] GameObject PanelWin;
    [SerializeField] GameObject PanelLose;
    [SerializeField] GameObject PanelDataSimulation;

    [SerializeField] TMPro.TextMeshProUGUI distXText;
    [SerializeField] TMPro.TextMeshProUGUI heightText;
    [SerializeField] TMPro.TextMeshProUGUI timeText;

    [SerializeField] TMPro.TextMeshProUGUI alertText;

    private void Start()
    {
        PanelAlert.SetActive(false);
        PanelDataSimulation.SetActive(false);
    }
    public void ShowAlert(bool stateActive, string alrtText = null)
    {
        PanelAlert.SetActive(stateActive);
        alertText.text = alrtText;
    }

    public void HidePanelData()
    {
        PanelData.SetActive(false);
        PanelAlert.SetActive(false);
    }

    public void ShowPanelData()
    {
        PanelData.SetActive(true);
    }

    public void WinState()
    {
        PanelWin.SetActive(true);
    }
    public void LoseState()
    {
        PanelLose.SetActive(true);
    }

    public void DataSimulation(float dist, float alt, float tiemp)
    {
        distXText.text = dist.ToString();
        heightText.text = alt.ToString();
        timeText.text = tiemp.ToString();
        PanelDataSimulation.SetActive(true);
    }
     
    public void CleanScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
