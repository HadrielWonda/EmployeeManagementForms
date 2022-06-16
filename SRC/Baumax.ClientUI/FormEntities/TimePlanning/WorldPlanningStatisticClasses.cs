using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{

    public enum WorldStaticticItemType
    {
        SummPlannedWorkingHours,
        TargetedHours,
        Difference,
        DifferenceInPercent
    }

    public class WorldPlanningStatisticItem
    {

        private string _ItemName;

        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
        private WorldStaticticItemType _ItemType;

        public WorldStaticticItemType ItemType
        {
            get { return _ItemType; }
            set { _ItemType = value; }
        }

        public WorldPlanningStatisticItem(string name, WorldStaticticItemType type)
        {
            ItemName = name;
            ItemType = type;
        }
    }


}
