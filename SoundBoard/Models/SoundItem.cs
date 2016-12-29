using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace SoundBoard.Models
{
    class SoundItem
    {
        public string Name;
        public string AudioPath;
        public string ImgPath;
        public AudioCategory Catrgory;

        public enum AudioCategory
        {
            Animals,
            Cartoons,
            Taunts,
            Warnings,
            Null
        }

        public SoundItem(string itemName, AudioCategory catrgory)
        {
            AudioPath = $"Assets/Audio/{catrgory.ToString()}/{itemName}.wav";
            ImgPath = $"Assets/Images/{catrgory.ToString()}/{itemName}.png";
            Catrgory = catrgory;
            Name = itemName;
        }
    }

    class SoundItemManager
    {
        public static ObservableCollection<SoundItem> GenerateSounds(
            SoundItem.AudioCategory category = SoundItem.AudioCategory.Null)
        {
            var currentList = new List<SoundItem>()
            {
                new SoundItem("Cat", SoundItem.AudioCategory.Animals),
                new SoundItem("Cow", SoundItem.AudioCategory.Animals),
                new SoundItem("Gun", SoundItem.AudioCategory.Cartoons),
                new SoundItem("Spring", SoundItem.AudioCategory.Cartoons),
                new SoundItem("Clock", SoundItem.AudioCategory.Taunts),
                new SoundItem("LOL", SoundItem.AudioCategory.Taunts),
                new SoundItem("Ship", SoundItem.AudioCategory.Warnings),
                new SoundItem("Siren", SoundItem.AudioCategory.Warnings)
            };
            if (category != SoundItem.AudioCategory.Null)
            {
                currentList = currentList.Where(p => p.Catrgory == category).ToList();
            }
            return new ObservableCollection<SoundItem>(currentList);
        }

        public static ObservableCollection<SoundItem> FilterItemByCategory(
            ObservableCollection<SoundItem> listIn,
            SoundItem.AudioCategory category)
        {
            foreach (var p in listIn)
            {
                if (p.Catrgory != category)
                    listIn.Remove(p);
            }
            return listIn;
        }

        public static ObservableCollection<SoundItem> FilterItemByName(
            ObservableCollection<SoundItem> listIn,
            string namePrefix)
        {
            foreach (var p in listIn)
            {
                if (!p.Name.StartsWith(namePrefix))
                    listIn.Remove(p);
            }
            return listIn;
        }
    }
}