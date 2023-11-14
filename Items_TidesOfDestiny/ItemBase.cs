using UnityEngine;

public class ItemBase : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private int itemTier;
    [SerializeField] private int itemPrice;
    [SerializeField] private Sprite itemSprite;

    public string ItemName => itemName;
    public string ItemDescription => itemDescription;
    public int ItemTier => itemTier;
    public int ItemPrice => itemPrice;
    public Sprite ItemSprite => itemSprite;
}
