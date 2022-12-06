using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AmmoCount : MonoBehaviour
{
    public GameObject textMesh;

    public void setAmmoCount(float val, float maxAmmo) {
        textMesh.GetComponent<TextMeshProUGUI>().SetText(val.ToString() + " / " + maxAmmo.ToString());
    }
}
