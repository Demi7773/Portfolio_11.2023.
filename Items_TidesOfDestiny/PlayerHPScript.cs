using System.Collections;
using UnityEngine;

public class PlayerHPScript : MonoBehaviour
{
    [Header("PlugIns")]
    [SerializeField] EquipmentController equipmentControls;

    [Header("HP Stats")]
    [SerializeField] private float playerCurrentHP;
    [SerializeField] private float playerMaxHP;
    private float playerMaxHPDefault = 100f;

    [Header("HP Stats")]
    [SerializeField] private float dmgReduction;
    private float dmgReductionDefault = 1f;

    [Header("IFrames on LoseHP")]
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private bool isInvulnerable = false;



    private void Awake()
    {
        equipmentControls.CalculateModifiers();
    }

    private void Start()
    {
        SetNewHPFromEquipment();
        SetNewDmgReductionFromEquipment();                
    }

    // Public methods to update values for new equipment modifiers
    // Needs to be called somewhere in Equipment/UI
    public void SetNewHPFromEquipment()
    {
        // add UI
        playerMaxHP = playerMaxHPDefault * equipmentControls.PlayerHPMod;
        SetToFullHP();
    }
    public void SetNewDmgReductionFromEquipment()
    {
        dmgReduction = dmgReductionDefault * equipmentControls.PlayerDmgReducMod;
    }


    // HealToFull and Heal
    public void SetToFullHP()
    {
        playerCurrentHP = playerMaxHP;
        float currentHPForEvent = playerCurrentHP / playerMaxHPDefault;
        HUDEvents.PlayerHealthUpdateEvent?.Invoke(new PlayerHealthUpdateEventData(currentHPForEvent));
    }

    public void HealHP(float healAmount)
    {
        playerCurrentHP += healAmount;

        if (playerCurrentHP > playerMaxHP)
        {
            playerCurrentHP = playerMaxHP;
        }

        float currentHPForEvent = playerCurrentHP / playerMaxHPDefault;
        HUDEvents.PlayerHealthUpdateEvent?.Invoke(new PlayerHealthUpdateEventData(currentHPForEvent));
    }


    // LoseHP with DamageReduction modifier and IFrames
    public void LoseHP(float dmg)
    {
        if (!isInvulnerable)
        {
            Debug.Log("Dmg in " + dmg);
            dmg -= dmg * (dmgReduction / 100f);
            Debug.Log("Dmg reduced to " + dmg);
            playerCurrentHP -= dmg;

            if (playerCurrentHP <= 0f)
            {
                // add GameOver
                Debug.Log("Game Over");
            }

            Debug.Log("PlayerHP " + playerCurrentHP + "/" + playerMaxHP);
            // add UI
            float currentHPForEvent = playerCurrentHP / playerMaxHPDefault;
            HUDEvents.PlayerHealthUpdateEvent?.Invoke(new PlayerHealthUpdateEventData(currentHPForEvent));
            StartCoroutine("Invulnerable");
        }
        else
            Debug.Log("isInvulnerable, no dmg taken");
            // add more if necessary
    }
    IEnumerator Invulnerable()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
    }



    // PERCENT HP GAIN AND LOSS - calculates flat values and calls HealHP/LoseHP
    public void LoseHPPercentMax(float percentLoss)
    {
        float dmg = percentLoss * 0.01f * playerMaxHP;
        LoseHP(dmg);
    }
    public void LoseHPPercentCurrent(float percentLoss)
    {
        float dmg = percentLoss * 0.01f * playerCurrentHP;
        LoseHP(dmg);
    }
    public void HealHPPercentMax(float percentHeal)
    {
        float healAmount = percentHeal * 0.01f * playerMaxHP;
        HealHP(healAmount);
    }
    public void HealHPPercentCurrent(float percentHeal)
    {
        float healAmount = percentHeal * 0.01f * playerCurrentHP;
    }



}
