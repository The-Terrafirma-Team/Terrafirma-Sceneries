using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using System.Threading;
using Terraria.ID;

namespace TerrafirmaSceneries.Common
{
    internal class MeteorMusic : ModSceneEffect
    {
        public override bool IsSceneEffectActive(Player player)
        {
            return player.ZoneMeteor;
        }
        public override void SetStaticDefaults()
        {
            MusicID.Sets.SkipsVolumeRemap[MusicLoader.GetMusicSlot("TerrafirmaSceneries/Assets/Music/Meteor")] = true;
        }
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
        public override int Music => MusicLoader.GetMusicSlot("TerrafirmaSceneries/Assets/Music/Meteor");
    }
    internal class HellAlternate : ModSceneEffect
    {
        public override void SetStaticDefaults()
        {
            MusicID.Sets.SkipsVolumeRemap[MusicLoader.GetMusicSlot("TerrafirmaSceneries/Assets/Music/Hell")] = true;
        }
        public static bool AltHellTheme = false;
        public override bool IsSceneEffectActive(Player player)
        {
            if(!Main.audioSystem.IsTrackPlaying(MusicID.Hell) && !Main.audioSystem.IsTrackPlaying(this.Music))
            {
                AltHellTheme = Main.rand.NextBool();
            }
            return player.ZoneUnderworldHeight && AltHellTheme;
        }
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;
        public override int Music => MusicLoader.GetMusicSlot("TerrafirmaSceneries/Assets/Music/Hell");
    }
}
