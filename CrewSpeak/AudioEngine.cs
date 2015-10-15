using System;
using System.IO;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace CrewSpeak
{
	public class AudioEngine
	{
		private WaveIn SoundInput;
		private Server ServerInstance;

		public AudioEngine (Server instance)
		{
			ServerInstance = instance;

			SoundInput = new WaveIn ();
			SoundInput.DeviceNumber = 1;
			SoundInput.WaveFormat = new WaveFormat(44100, 1);
			SoundInput.DataAvailable += OnDataAvailable;
		}

		public void PlayRawAudio(byte[] bytes)
		{
			DirectSoundOut SoundOutput = new DirectSoundOut();

			IWaveProvider provider = new RawSourceWaveStream(
				new MemoryStream(bytes), new WaveFormat());

			SoundOutput.Init(provider);
			SoundOutput.Play();
		}

		private void OnDataAvailable (object sender, WaveInEventArgs args)
		{
			ServerInstance.Write (args.Buffer, args.BytesRecorded);
		}
	}
}

