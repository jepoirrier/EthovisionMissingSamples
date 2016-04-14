# Ethovision Missing Samples (EMS), a tool to find missing samples from tracks exported from Ethovision

## Introduction

EthoVision (from [Noldus](http://www.noldus.com/)) is a software that allows tracking of moving animals in a defined area. It's useful in the Morris water maze or the Open Field, for example. Since the Morris water maze consists of a pool with water, your animal can sometimes sink (because of physical fatigue, pharmacological treatement, etc.). If the videotracking software cannot find your animal during one frame, it can consider this as a missed sample.

Knowing the amount of missed samples can become important if you rely on parameters like "total distance", "average speed", etc. Indeed, these parameters are increasingly influenced (biaised) when the number of missed samples increases.

I didn't find a simple way to compute the total number of missed samples in Ethovision. But Ethovision allows us to export tracks in a text-file with comma-separated variables.

The goal of EMS is to parse exported tracks from Ethovision and to report the number of missed samples in one track.

## Features:

* Open and parse tracks exported from Ethovision (version 3.x, at least: not tested with other versions)
* Guess sample rate from data (but also allows you to change it, in case the guess is wrong)
* Computes the number of missed samples, the total duration of the track (in seconds), the total duration of missed samples (in seconds) and the percentage of missed samples (compared to the total number of samples).

## Software

Ethovision Missing Samples screenshot can be found in the screenshots/ directory.

Download the latest version of EMS in the bin/ directory. 

This directory gives all files, including the executable (the software you'll use). You can run this software under MS-Windows, provided you have the .Net framework. If you regularly update your computer, you should already have it. Anyway, you can download it from Microsoft and install it.

This software is released under the GNU General Public Licence (GPL): C#/.Net source code is in the src/ directory.
Copyright (C) belongs to Jean-Etienne Poirrier, 2006-2016. You can contact me at jepoirrier "at" gmail.com. Please report if you have any problem, comment or if you would like new features in this software.

The software is so simple that there should be no problem to use it. If you really want some help, you can watch this video:

[![Ethovision Missing Samples demo](http://img.youtube.com/vi/4o8VnQnYcyc/0.jpg)](http://www.youtube.com/watch?v=4o8VnQnYcyc)

If you are using Ethovision, you might be interested in another small tool from me: [Ethovision Paste Tracks](https://github.com/jepoirrier/EthovisionPasteTracks).

## How to export tracks from Ethovision

The first thing to configure in Ethovision is the way it will represent the fact that it cannot find your animal. In my experiments, I don't extrapolate missing data between two known points. I just assign a missing value when Ethovision doesn't find my animal.

To export tracks from Ethovision, you must have selected your tracks (for graph or statistics). In the file menu, just choose the "Export Parameters and Raw Data".

Now you can use EMS with the exported tracks. A sample track is in the sampledata/ directory.

