using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundBoard.Models;

namespace SoundBoard.Models
{
    class MenuItem
    {
        public SoundItem.AudioCategory Category;
        public string IconPath;
        public string ItemName;

        public MenuItem(SoundItem.AudioCategory category)
        {
            Category = category;
            ItemName = Category.ToString();
            IconPath = $"Assets/Icons/{ItemName.ToLower()}.png";
        }
    }

    class MenuItemManager
    {
        public static List<MenuItem> GetMenuItems()
        {
            var currentList = new List<MenuItem>()
            {
                new MenuItem(SoundItem.AudioCategory.Taunts),
                new MenuItem(SoundItem.AudioCategory.Cartoons),
                new MenuItem(SoundItem.AudioCategory.Animals),
                new MenuItem(SoundItem.AudioCategory.Warnings)
            };

            return currentList;
        }
    }
}
