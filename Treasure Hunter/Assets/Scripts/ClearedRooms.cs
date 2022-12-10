using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearedRooms : MonoBehaviour
{
    public GameObject textMesh;

    public void setRoomNo(float cleared, float numRooms) {
        textMesh.GetComponent<TextMeshProUGUI>().SetText("Cleared - " + cleared.ToString() + "/" + numRooms.ToString());
    }
}
