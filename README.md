##AmiMat (アミマト)
"simple animation library build for you."

###Introduction

The purpose of this project is to create a simple to use toolset that will be useful for `desktop widgets` `basic animation` and much more. It uses a simple gif animation file to creat such magic.

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
Win32: **Download** [![icon](http://nvlabs.github.com/cub/download-icon.png)](http://devfish.org/AmiMat/20131219/Overlay.zip "Download")

Animation Creator
Win32: **Download** [![icon](http://nvlabs.github.com/cub/download-icon.png)](http://devfish.org/AmiMat/20131219/AC.zip "Download")

###Special Thanks
[**wyvernzora**](https://github.com/jluchiji) for the inspiration of a animation engine based on Gif

**TingWen Lai** for the inspriation on the name

[**Tohoku University**](http://www.tohoku.ac.jp/japanese/) for a quiet library so I can design the first prototype of AmiMat

**Omachi Lab** for providing me a office and do my research