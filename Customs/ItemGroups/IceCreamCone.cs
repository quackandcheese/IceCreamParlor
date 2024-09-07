using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenIceCreamParlor.Customs.Items;
using UnityEngine;

namespace KitchenIceCreamParlor.Customs.ItemGroups
{
    public class IceCreamCone : CustomItemGroup<IceCreamConeItemGroupView>
    {
        public override string UniqueNameID => "IceCreamCone";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Ice Cream Cone").AssignMaterialsByNames();
        public override ItemValue ItemValue => ItemValue.Medium;
        public override bool CanContainSide => false;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<CakeCone>().GameDataObject
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    // If want to add new flavors, set itemset to Requires unlock and add UnlockIngredients to base dish
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamVanilla),
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamChocolate),
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamStrawberry)
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    // If want to add new flavors, set itemset to Requires unlock and add UnlockIngredients to base dish
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.NutsIngredient),
                    (Item)GDOUtils.GetCustomGameDataObject<FudgeSauce>().GameDataObject,
                    (Item)GDOUtils.GetCustomGameDataObject<Sprinkles>().GameDataObject
                },
                Min = 0,
                Max = 1,
                RequiresUnlock = true,
                IsMandatory = false
            }
        };

        public override void OnRegister(ItemGroup gameDataObject)
        {
            base.OnRegister(gameDataObject);

            Prefab.GetComponent<IceCreamConeItemGroupView>()?.Setup(Prefab);
        }
    }

    public class IceCreamConeItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            ComponentGroups = new()
            {
                new()
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamVanilla),
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Scoop1/Vanilla"),
                    DrawAll = true
                },
                new()
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamChocolate),
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Scoop1/Chocolate"),
                    DrawAll = true
                },
                new()
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamStrawberry),
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Scoop1/Strawberry"),
                    DrawAll = true
                },
                new()
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<CakeCone>().GameDataObject,
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cake Cone"),
                    DrawAll = true
                },
                new()
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<FudgeSauce>().GameDataObject,
                    Objects = new() 
                    {
                        GameObjectUtils.GetChildObject(prefab, "Scoop1/Fudge Sauce"),
                    },
                    DrawAll = true
                },
                new()
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<Sprinkles>().GameDataObject,
                    Objects = new()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Scoop1/Sprinkles"),
                    },
                    DrawAll = true
                },
                new()
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.NutsIngredient),
                    Objects = new()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Scoop1/Nuts"),
                    },
                    DrawAll = true
                }
            };

            ComponentLabels = new()
            {
                new()
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<CakeCone>().GameDataObject,
                    Text = "Cc"
                },
                new()
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamChocolate),
                    Text = "C"
                },
                new()
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamStrawberry),
                    Text = "S"
                },
                new()
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamVanilla),
                    Text = "V"
                },
                new()
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<FudgeSauce>().GameDataObject,
                    Text = "F"
                },
                new()
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<Sprinkles>().GameDataObject,
                    Text = "Sp"
                },
                new()
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.NutsIngredient),
                    Text = "N"
                },
            };
        }
    }
}