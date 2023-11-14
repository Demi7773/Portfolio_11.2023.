using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentController", menuName = "Scriptables/Holders")]
public class EquipmentController : ScriptableObject
{
    [Header("References")]
    [SerializeField] private ShipPartsHolder shipPartsHolder;

    [Header("Equipped Items")]
    [SerializeField] private ItemCannon cannons;
    [SerializeField] private ItemArmor armor;
    [SerializeField] private ItemSails sails;
    [SerializeField] private ItemRudder rudder;
    [SerializeField] private ItemCrew crew;
    [SerializeField] private ItemFlag flag;
    [SerializeField] private ItemAmmo ammoType;
    [SerializeField] private ItemHelm helm;

    [Header("Combined equipmentController modifiers")]
    [SerializeField] private float playerHPMod;
    [SerializeField] private float playerDmgReducMod;
    [SerializeField] private float playerSpeedMod;
    [SerializeField] private float playerTurnMod;
    [SerializeField] private float playerStoppingMod;
    [SerializeField] private float playerDmgMod;
    [SerializeField] private float playerReloadSpeedMod;
    [SerializeField] private float playerRangeMod;

    [SerializeField] private int playerDiplomacyLvl;
    [SerializeField] private int playerEncountersMod;



    // new public variables for read only reference
    public float PlayerHPMod => playerHPMod;
    public float PlayerDmgReducMod => playerDmgReducMod;
    public float PlayerSpeedMod => playerSpeedMod;
    public float PlayerTurnMod => playerTurnMod;
    public float PlayerStoppingMod => playerStoppingMod;
    public float PlayerDmgMod => playerDmgMod;
    public float PlayerReloadSpeedMod => playerReloadSpeedMod;
    public float PlayerRangeMod => playerRangeMod;

    public int PlayerDiplomacyLvl => playerDiplomacyLvl;
    public int PlayerEncountersMod => playerEncountersMod;


    // Sets all value modifiers for items equipped. Use Public Get methods below to read current values for reference
    // Currently called from PlayerHPScript to initialize - figure out better system
    public void CalculateModifiers()
    {
        // tu samo invokeam event za dohvacanje spriteova ovak: ammoType.ItemSprite 
        //tak i za ostale

        playerHPMod = armor.ItemHPMod * crew.ItemHPMod;
        playerDmgReducMod = armor.ItemDmgReducMod;
        playerSpeedMod = sails.ItemSpeedMod * armor.ItemSpeedMod * crew.ItemSpeedMod * rudder.ItemSpeedMod * helm.ItemSpeedMod;
        playerTurnMod = sails.ItemTurnRateMod * rudder.ItemTurnRateMod * crew.ItemTurnRateMod * helm.ItemTurnRateMod;
        playerStoppingMod = sails.ItemStoppingMod * rudder.ItemStoppingMod * helm.ItemStoppingMod;
        playerDmgMod = cannons.ItemDmgMod * ammoType.ItemDmgMod;
        playerReloadSpeedMod = cannons.ItemReloadSpeedMod * crew.ItemReloadSpeedMod * ammoType.ItemReloadSpeedMod;
        playerRangeMod = cannons.ItemRangeMod * ammoType.ItemRangeMod;

        playerDiplomacyLvl = flag.DiplomacyLvl;
        playerEncountersMod = flag.RandomEncountersAvailable;

        HUDEvents.HUDInventoryUpdateEvent?.Invoke(new HUDInventoryUpdateEventData(cannons.ItemSprite, armor.ItemSprite, sails.ItemSprite, rudder.ItemSprite, crew.ItemSprite));
    }

    // Needs to be called somewhere (UI, event?)
    // Missing Item index. Myb have a List of all potential items here in same order? or figure out better system
    // myb change ShipPartsHolder reference?
    public void SetShipPartsAccordingToEquipped()
    {
        //shipPartsHolder.SetShipBodyMesh();
        //shipPartsHolder.SetShipSailsMesh();
        //shipPartsHolder.SetShipFlagMesh();
    }
}
