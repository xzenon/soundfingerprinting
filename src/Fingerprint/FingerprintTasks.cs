using System;
using System.Threading.Tasks;
using SoundFingerprinting;
using SoundFingerprinting.Audio;
using SoundFingerprinting.Builder;
using SoundFingerprinting.Data;
using SoundFingerprinting.InMemory;
using SoundFingerprinting.Emy;
using System.Collections.Generic;
using System.Linq;

namespace Fingerprint
{
    public class FingerprintTasks
    {
        public FingerprintTasks()
        {
        }

        private readonly IModelService modelService = new InMemoryModelService(); // store fingerprints in RAM

        //private readonly IAudioService audioService = new SoundFingerprintingAudioService();
        private readonly IAudioService audioService = new FFmpegAudioService();

        public async Task StoreForLaterRetrieval(string pathToAudioFile)
        {
            var track = new TrackInfo("1", "Ta4to", "Boombox");

            // create fingerprints
            var hashedFingerprints = await FingerprintCommandBuilder.Instance
                                        .BuildFingerprintCommand()
                                        .From(pathToAudioFile)
                                        .UsingServices(audioService)
                                        .Hash();

            // store hashes in the database for later retrieval
            modelService.Insert(track, hashedFingerprints);

            Console.WriteLine("StoreForLaterRetrieval:" + modelService.Info.First().ToString());
        }
    }
}
