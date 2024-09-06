using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenIceCreamParlor.Customs.ItemGroups;
using KitchenIceCreamParlor.Customs.Items;
using UnityEngine;

namespace KitchenIceCreamParlor.Customs.Dishes
{
    public class IceCreamDish : CustomDish
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "IceCreamDish";

        // ExpReward - Determines how much XP this Unlock provides.
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        // IsUnlockable - When TRUE this Unlock can appear in the card selector.
        public override bool IsUnlockable => true;

        // UnlockGroup - Determines what type of Unlock this is.
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        // CardType - Determines when this Unlock can be selected.
        public override CardType CardType => CardType.Default;

        // CustomerMultiplier - Determines the customer difference this Unlock provides.
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        // Type - This is used to decide what phase this Dish should be ordered.
        public override DishType Type => DishType.Base;

        // Difficulty - This is displayed in the lobby. (0 - 5)
        public override int Difficulty => 1;

        // StartingNameSet - The list of names used to decide the default Restaurant name.
        public override List<string> StartingNameSet => new List<string>
        {
            "I scream you scream",
        };

        // MinimumIngredients - The ingredients required to make this Dish.
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamVanilla),
            (Item)GDOUtils.GetCustomGameDataObject<CakeCone>().GameDataObject,
        };

        // IconPrefab - This is the Icon displayed in the lobby.
        public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("Ice Cream Dish Icon").AssignMaterialsByNames();

        // ResultingMenuItems - What menu Items are available to customers after unlocking this Dish.
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<IceCreamCone>().GameDataObject,
                Phase = MenuPhase.Main,
                Weight = 1,
                DynamicMenuType = DynamicMenuType.Static,
                DynamicMenuIngredient = null
            }
        };

        // IsAvailableAsLobbyOption - When TRUE this Dish will appear in the lobby.
        public override bool IsAvailableAsLobbyOption => true;

        // Recipe - This is the recipe displayed when unlocking this Dish.
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Grab a cone, interact with the ice cream freezer to select a flavour, and then grab to take a scoop." }
        };

        // InfoList - This is used to assign localisation to this Dish.
        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
        {
            (Locale.English, new UnlockInfo
            {
                Name = "Ice Cream",
                Description = "Adds ice cream as a main",
                FlavourText = ""
            })
        };
    }
}