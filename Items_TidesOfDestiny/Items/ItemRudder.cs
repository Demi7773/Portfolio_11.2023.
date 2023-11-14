using UnityEngine;

[CreateAssetMenu(fileName = "Rudder", menuName = "Items/Rudders")]
public class ItemRudder : ItemBase
{
    [SerializeField] private float itemSpeedMod;
    [SerializeField] private float itemTurnRateMod;
    [SerializeField] private float itemStoppingMod;

    public float ItemSpeedMod => itemSpeedMod;
    public float ItemTurnRateMod => itemTurnRateMod;
    public float ItemStoppingMod => itemStoppingMod;
}
