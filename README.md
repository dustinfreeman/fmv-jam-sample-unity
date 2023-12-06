# fmv-jam-sample-unity

For [FMV Jam NYC](https://itch.io/jam/fmv-jam-nyc)

An example of Full-Motion Video (FMV) usage in a Unity WebGL build, where the player is a first-person controller, and NPC video billboards uses chroma key (ie green screen)

Playable on itch: https://escapecharacter.itch.io/fmv-jam-sample-unity

![image](https://github.com/dustinfreeman/fmv-jam-sample-unity/assets/940836/934b524a-bd21-42dd-897b-880844a244b0)

## Contribution

Please contribute! Please make an issue and/or a pull request if you find a problem or have an improvement. 

Original code by @ahintoflime

## Using Video in Unity

Unity and especially WebGL builds are incredibly finicky; it is easy to lose many hours debugging poorly-documented issues that you'd rather spend being creative.

We built this sample as a demo that "definitely works". We strongly recommend you build off of this, otherwise you may run into issues.

### Preparing Video Files

One common issue is incomptable codecs, based on how the video was recorded or edited. Here's an example error from Unity:

![image](https://github.com/dustinfreeman/fmv-jam-sample-unity/assets/940836/ca817dac-272f-4740-8df6-4f0b0fbc04d7)

You should always just convert the video instead of trying to get Unity or another engine to play the codec.

The easier conversion app is [Handbrake](https://handbrake.fr/). Handbrake's default settings should convert to a usable codec, H.264 is a good choice:

![image](https://github.com/dustinfreeman/fmv-jam-sample-unity/assets/940836/e799f17d-2a06-4988-ad64-b15dd922fc94)

### Chroma Key

The RenderMat material on the video billboard uses the ChromaKey shader. You may need to adjust these values based on your own assets. 
Assets recorded in different physical setups may need different settings, and it's easiest to manage to duplicate ChromaKey shader per physical setup.

![image](https://github.com/dustinfreeman/fmv-jam-sample-unity/assets/940836/b051b0db-11bb-4464-90e2-acb3aa7965c1)

### Getting the Video File into the Clip

This is extremely finicky, and even if it "works fine" in editor, it's not guaranteed it works in a build. Be paranoid and test yourself!

NOTE: The GODOT engine prefers .ogv videos. But this does not work in Unity. Unfortunately, [WebGL/video format support isn't documented by Unity](https://docs.unity3d.com/Manual/VideoSources-FileCompatibility.html).

To ensure your assets load into a VideoPlayer object in editor and when shipped:
1. Put all your video assets directly in `Assets/StreamingAssets` ([more info](https://docs.unity3d.com/ScriptReference/Application-streamingAssetsPath.html))
2. Set each VideoPlayer component Source to URL, and you may leave the URL field empty
   
![image](https://github.com/dustinfreeman/fmv-jam-sample-unity/assets/940836/9578c7ef-cffd-4c90-8b7f-43db31fb48ed)

3. Attach our custom `LoadVideo` component to each GameObject containing a VideoPlayer
4. In the `LoadVideo` component, set `videoName` to the filename with extension (even though this doesn't show in the Unity project view). Set the width/height to the pixel dimension of the video.

![image](https://github.com/dustinfreeman/fmv-jam-sample-unity/assets/940836/78be020d-5315-48c2-8d11-a36ad018a9ff)

Note: If you're playing multiple videos, then you're probably going to end up with duplicating assets, since each VideoPlayer renders to a texture, which is attached to a material. If you don't duplicate these, then they'll end up with one video overwriting over all others. You can do this manually, or in code. Check out what `LoadVideo.cs` does, which isn't necessarily the best solution.







