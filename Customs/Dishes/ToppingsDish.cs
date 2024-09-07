using KitchenData;
using KitchenIceCreamParlor.Customs.ItemGroups;
using KitchenIceCreamParlor.Customs.Items;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenIceCreamParlor.Customs.Dishes
{
    public class ToppingsDish : CustomDish
    {
        public override string UniqueNameID => "ToppingsDish";
        public override DishType Type => DishType.Extra;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override int Difficulty => 4;

        public override List<Unlock> HardcodedRequirements => new()
        {
            (Unlock)GDOUtils.GetCustomGameDataObject<IceCreamDish>().GameDataObject
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = (Item)GDOUtils.GetCustomGameDataObject<FudgeSauce>().GameDataObject,
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<IceCreamCone>().GameDataObject
            },
            new Dish.IngredientUnlock
            {
                Ingredient = (Item)GDOUtils.GetCustomGameDataObject<Sprinkles>().GameDataObject,
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<IceCreamCone>().GameDataObject
            },
            new Dish.IngredientUnlock
            {
                Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.NutsIngredient),
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<IceCreamCone>().GameDataObject
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            (Item)GDOUtils.GetCustomGameDataObject<Sprinkles>().GameDataObject
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> 
        {
            { Locale.English, "Interact with the toppings freezer to select a topping, grab while holding ice cream in cone to add." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Toppings", "Adds fudge, sprinkles, and nuts as ice cream cone toppings", "") )
        };
    }
}
