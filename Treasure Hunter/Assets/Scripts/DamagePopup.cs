using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textmesh;
    private Color color, textColor;
    public float moveSpeed = 5f;
    public float disppearTimer = 0.5f;

    public DamagePopup Create(Vector3 position, float damageAmount, int owner) {
        Transform damagePopupTransform = Instantiate(this.transform, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();

        switch(owner) {
            case 1:
            textColor = new Color(1, 1, 0);
            break;

            case 2:
            textColor = new Color(1, 0, 0);
            break;

            case 3:
            textColor = new Color(0, 1, 0);
            break;
        }

        damagePopup.GetComponent<TextMeshPro>().color = textColor;

        damagePopup.Setup(damageAmount);

        return damagePopup;
    }

    private void Awake() {
        textmesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(float damageAmount) {
        textmesh.SetText(damageAmount.ToString());
    }

    void Update() {
        transform.position += new Vector3(0, (moveSpeed*Time.deltaTime), 0);

        disppearTimer -= Time.deltaTime;

        if(disppearTimer <= 0) {
            float disppearSpeed = 3f;
            color.a -= disppearSpeed * Time.deltaTime;
            textmesh.color = color;

            if(color.a <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
