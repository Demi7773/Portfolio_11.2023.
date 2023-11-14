using UnityEngine;

[CreateAssetMenu(fileName = "Sails", menuName = "Items/Sailss")]
public class ItemSails : ItemBase
{
    [SerializeField] private float itemSpeedMod;
    [SerializeField] private float itemTurnMod;
    [SerializeField] private float itemStoppingMod;

    public float ItemSpeedMod => itemSpeedMod;
    public float ItemTurnRateMod => itemTurnMod;
    public float ItemStoppingMod => itemStoppingMod;
}
