using UnityEngine;
using TMPro;
public class StatsShow : MonoBehaviour
{
    public TextMeshProUGUI ReputationScreen;
    private void Update() {
        ReputationScreen.SetText("Reputation: " + Citizen.CurrentReputation);
    }
}
