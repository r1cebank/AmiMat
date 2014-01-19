<div style="width: 100%; margin: 20px; text-align: center;">
	<img alogn="center" src="/Animat.UI/Assets/Icons/logo.png" />
	<h1>AniMat Framework</h1>
	<h4>— "Versatile and lightweight animation solution for your project"</h2>
</div>


##Introduction
The **AniMat** project is a collaboration by [R1cebank](http://github.com/R1cebank) and [Wyvernzora](https://github.com/jluchiji) to create a lightweight animation framework. The animation framework is mainly intended for developing desktop sprites, but it would also be perfect for other 2D animations, including games.\

The AniMat Studio will support multiple project types, including **AniMat Resource Files**, **BarloX Animation** and even **GIF**.

##Project Types
###AniMat Resource File
AniMat Resource File is a great way to unify all your image frames and action sequences into one package. The AniMat is specifically designed for game developers, who need a high level of flexibility and control over the animation. However, if your animation mostly runs on its own, you may consider using BarloX Animation.

###BarloX Animation
BarloX Animation is a plug-and-play type of animation file, with a self-guiding animation system. It can independently decide what animation sequence to play next, and supports both random decisions and decisions based on external events. However, if you need greater control over your animation that simple sequence jumps, please consider using AniMat Resource File.

###GIF File
Good ol' GIF is supported everywhere, so it is your best bet if you wanna use your animation all over the place. You can render you existing project of any type to a GIF image, but please note that interactive features are not supported there.



##Original Documentation by R1cebank
###Why Gif?

I chose to use Gif files because many of the Gif animation file are packed with information, but because the nature of Gif file structure, it is just a infinite loop of one action. Now using AmiMat you can make the Gif file do more.

###How this will work?

AmiMat is action-based animation engine. Which means the AmiMat editor you use will split a Gif file into its invidual frames and user will be able to define what frame to what frame is an action. After editing the Gif file you will get a file that have much more information in it:

	AMTPackage
		AMTAnimation (Store everything)
			AMTManifest (Store all the actions in one Animation)
			AMTAction (Define an action)
				AMTFrame (Define the property of a frame)
		AMTLua (Currently underdevelopment)
		AMTResource (Currently underdevelopment)
		
###So what is the progress of this?

AmiMat is completed with basic file structures and I am running multiple test to make sure AmiMat will unleash the full power of an Gif file.

###What is included in this?

AmiMat is a full-size animation engine build using C#, it is currently build under .NET 4.5 and will be ported to other platform and languages later once I have finished polishing it. It will soon include everything you need to make an AmiMat animation, this will include an Editor and a Viewer and API Documentation. More feature will be avaliable upon request.

###Downloads

Overlay Player
Win32: **Download** [![icon](http://nvlabs.github.com/cub/download-icon.png)](http://devfish.org/AmiMat/20140111/Overlay.zip "Download")

Animation Creator
Win32: **Download** [![icon](http://nvlabs.github.com/cub/download-icon.png)](http://devfish.org/AmiMat/20140111/AC.zip "Download")

###Special Thanks
[**wyvernzora**](https://github.com/jluchiji) for the inspiration of a animation engine based on Gif

**TingWen Lai** for the inspriation on the name

[**Tohoku University**](http://www.tohoku.ac.jp/japanese/) for a quiet library so I can design the first prototype of AmiMat

**Omachi Lab** for providing me a office and do my research

[**blitzkrieged**](http://www.codeproject.com/Members/blitzkrieged) for the great algorithm to split Gif files

[**James Newton-King**](http://james.newtonking.com/bio) for the wonderful Json.NET library

[**雪月佳 さん**](http://seiga.nicovideo.jp/seiga/im3277366) for the beautiful 島風たん Gif files