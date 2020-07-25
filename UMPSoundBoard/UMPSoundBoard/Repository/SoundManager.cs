using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMPSoundBoard.Models;

namespace UMPSoundBoard.Repository
{
    public class SoundManager
    {
        private static List<Sound> GetSounds()
        {
            return new List<Sound>()
            {
                new Sound("Cat",SoundCategory.Animals),
                new Sound("Cow",SoundCategory.Animals),
                new Sound("Gun",SoundCategory.Cartoons),
                new Sound("Spring",SoundCategory.Cartoons),
                new Sound("Clock",SoundCategory.Taunts),
                new Sound("LOL",SoundCategory.Taunts),
                new Sound("Ship",SoundCategory.Warnings),
                new Sound("Siren",SoundCategory.Warnings)
            };
        }

        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allSounds = GetSounds();
            sounds.Clear();
            allSounds.ForEach(x => sounds.Add(x));
        }

        public static void GetSoundsByCategory(ObservableCollection<Sound> sounds, SoundCategory category)
        {
            var allSounds = GetSounds();
            var filteredSounds = allSounds.Where(x => x.Category == category).ToList();
            sounds.Clear();
            filteredSounds.ForEach(x => sounds.Add(x));

        }

        public static void GetSoundByName(ObservableCollection<Sound> sounds, string name)
        {
            var allSounds = GetSounds();
            var fillteredSounds = allSounds.Where(x => x.Name.Contains(name)).ToList();
            sounds.Clear();
            fillteredSounds.ForEach(x => sounds.Add(x));
        }
    }
}
