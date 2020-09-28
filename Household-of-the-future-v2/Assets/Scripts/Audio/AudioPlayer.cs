using System;
using System.IO;
using OVRSimpleJSON;
using UnityEngine;

public class AudioPlayer: MonoBehaviour {
    public Sound[] sounds;
    public SoundInfo[] audioInfoArray;
    private JSONNode info;

    private void Awake() {
        importAudioHeadersFromJSON();
    }

    public void play(string name) {
        Sound file = getSoundFile(name);
        if (soundFileExists(file)) {
            interruptPlayingSounds();
            file.source.Play();
        } else {
            Debug.LogError($"Sound: {name} does not exist. Is the name correct?");
        }
    }

    private Sound getSoundFile(string name) {
        return Array.Find(sounds, sound => sound.name == name);
    }

    private bool soundFileExists(Sound file) {
        return file != null;
    }

    public void interruptPlayingSounds() {
        foreach (Sound sound in sounds) {
            sound.source.Stop();
        }
    }

    private void importAudioHeadersFromJSON() {
        TextAsset asset = Resources.Load<TextAsset>("Audio");
        using(StreamReader reader = new StreamReader(new MemoryStream(asset.bytes))) {
            string json = reader.ReadToEnd();
            info = JSON.Parse(json);
            audioInfoArray = JsonHelper.getJsonArray<SoundInfo>(info["files"].ToString());
            reader.Close();
        }

        sounds = new Sound[audioInfoArray.Length];
        for (int i = 0; i < audioInfoArray.Length; i++) {
            Sound sound = new Sound(audioInfoArray[i]);
            sounds[i] = sound;
        }

        foreach (Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

}