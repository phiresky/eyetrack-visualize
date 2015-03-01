# eyetrack-visualize

Sample result: https://phiresky.github.io/eyetrack-visualize

Tool to visualize a logged eye track from watching a video in the browser.


[LogEyePosition.cs](LogEyePosition.cs) is a small script that logs the eye position using the Tobii SDK and a Tobii Eyetracker (e.g. [EyeX](http://www.tobii.com/eye-experience)) into a simple plain text file.

That file is read by the browser to produce a heatmap overlay over the video.
