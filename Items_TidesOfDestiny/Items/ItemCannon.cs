using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cannon", menuName = "Items/Cannons")]
public class ItemCannon : ItemBase
{
    [SerializeField] private float itemDmgMod;
    [SerializeField] private float itemReloadSpeedMod;
    [SerializeField] private float itemRangeMod;

    public float ItemDmgMod => itemDmgMod;
    public float ItemReloadSpeedMod => itemReloadSpeedMod;
    public float ItemRangeMod => itemRangeMod;
}