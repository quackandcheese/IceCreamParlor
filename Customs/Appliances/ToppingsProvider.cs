using Kitchen;
using KitchenData;
using KitchenIceCreamParlor;
using KitchenIceCreamParlor.Customs.Items;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenIceCreamParlor.Customs.Appliances
{
    class ToppingsProvider : CustomAppliance
    {
        public override string UniqueNameID => "Toppings Provider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Toppings Provider").AssignMaterialsByNames();
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;


        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Toppings", "Provides three different ice cream toppings", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new()
        {
            KitchenPropertiesUtils.GetCItemProvider(ItemReferences.NutsIngredient, 0, 0, false, false, false, false, false, false, false),
            new CVariableProvider()
            {
                Current = 0,
                Provide1 = ItemReferences.NutsIngredient,
                Provide2 = GDOUtils.GetCustomGameDataObject<FudgeSauce>().ID,
                Provide3 = GDOUtils.GetCustomGameDataObject<Sprinkles>().ID
            }
        };


        public override void OnRegister(Appliance gameDataObject)
        {
            Prefab.AddComponent<VariableProviderView>().Animator = Prefab.GetComponent<Animator>();

            var holdTransform = Prefab.GetChild("HoldPoint").transform;
            var holdPoint = Prefab.AddComponent<HoldPointContainer>();
            holdPoint.HoldPoint = holdTransform;
        }
    }
}
