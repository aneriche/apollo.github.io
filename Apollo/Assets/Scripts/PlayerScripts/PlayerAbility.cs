using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private Image abilityPanel;
    [SerializeField] private GameObject forceFieldPrefab;
    private bool expand = false;
    private float expandTime = 0.3f;
    private GameObject ff;
    private float fillVal = 0f;
    public void activateAbility() {
        //abilityPanel.gameObject.SetActive(true);
        ff = Instantiate(forceFieldPrefab, gameObject.transform);
        expand = true;
    }

    public void fillPanel(int keyCount) {
        if (keyCount > 2) {
            abilityPanel.fillAmount = 1.0f;
            fillVal = 1.0f;
        }
        else if (keyCount == 2) {
            abilityPanel.fillAmount = 1.0f;
            fillVal = 1.0f;
        }
        else if (keyCount == 1) {
            abilityPanel.fillAmount = 0.5f;
            fillVal = 0.5f;
        }
        else if (keyCount == 0) {
            abilityPanel.fillAmount = 0f;
            fillVal = 0f;
        }
    }

    public void clearPanel() {
        abilityPanel.fillAmount = 0f;
        fillVal = 0f;
    }

    void Update() {
        if (expand) {
            expandTime -= Time.deltaTime;
            if (expandTime >= 0) {
                ff.gameObject.transform.localScale += new Vector3(1,1,1);
            }
            else {
                Destroy(ff.gameObject);
                expand = false;
                expandTime = 0.3f;
                clearPanel();
            }
        }
    }
}
