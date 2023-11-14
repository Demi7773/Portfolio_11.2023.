using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Items/Ammos")]
public class ItemAmmo : ItemBase
{
    [SerializeField] private float itemReloadSpeedMod;
    [SerializeField] private float itemDmgMod;
    [SerializeField] private float itemRangeMod;

    public float ItemReloadSpeedMod => itemReloadSpeedMod;
    public float ItemDmgMod => itemDmgMod;
    public float ItemRangeMod => itemRangeMod;
}
