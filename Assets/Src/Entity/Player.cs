using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Tank
{
    public GameObject HPDisplay;
    TextMeshProUGUI Display;

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        Display = HPDisplay.GetComponent<TextMeshProUGUI>();
        UpdateHPDisplay();
    }

    // Update is called once per frame
    protected void Update()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LookAtTarget(mouseScreenPosition);
        Control = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        FireControl = Input.GetMouseButton(0);
        base.Update();
    }

    protected override void Die()
    {
        GameManager.EndGameDefeat();
    }

    public override int ModifyHitpoint(int amount) {
        int res = base.ModifyHitpoint(amount);
        UpdateHPDisplay();
        return res;
    }

    void UpdateHPDisplay()
    {
        Display.text = "HP " + HitPoint.ToString() + " / " + MaxHitPoint.ToString();
    }
}
