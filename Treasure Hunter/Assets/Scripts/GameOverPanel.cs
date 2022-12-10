using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
   public GameObject panel, clearedText, timeText;
   public Timer timerPanel;


   public void gameOver() {
        panel.SetActive(true);

        float percentage = (PlayerStats.playerStats.clearedRooms / PlayerStats.playerStats.numRooms);
        string text = "Cleared rooms - " + PlayerStats.playerStats.clearedRooms + "/" + PlayerStats.playerStats.numRooms;
        text += string.Format("\n - {0:P2}" , percentage);

        clearedText.GetComponent<TextMeshProUGUI>().SetText(text);

        text = "Time - " + timerPanel.text;

        timeText.GetComponent<TextMeshProUGUI>().SetText(text);
   }

    public void ExitGame() {
        Debug.Log("Exiting");
        SceneManager.LoadScene(0);
    }

    public void Restart() {
        Debug.Log("Restarting");
        SceneManager.LoadScene(1);
    }
}
