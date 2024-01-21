using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{

    [Header("Ability 1")]
    public Image abilityImage1;
    public Text abilityText1;
    public KeyCode ability1Key;
    public float ability1CoolDown = 5;

    private bool isAbility1Cooldown = false;

    private float currnetAbility1Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;

        abilityText1.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Ability1Input();

        AbilityCooldown(ref currnetAbility1Cooldown, ability1CoolDown, ref isAbility1Cooldown, abilityImage1, abilityText1);
    }

    private void Ability1Input()
    {
        if(Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        {
            isAbility1Cooldown = true;
            currnetAbility1Cooldown = ability1CoolDown;
        }
    }

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f) 
            {
                isCooldown = false;
                currentCooldown = 0f;

                if(skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if(skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if(skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if(skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}
