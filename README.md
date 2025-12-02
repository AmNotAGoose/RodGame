# RodGame Level Editor

### new demo video
https://youtu.be/R-nftbQG_LQ

### old demo video
https://youtu.be/4JmB20C4xns

### what is it
- a (unfinished) level editor/rhythm game framework for a (so far) non existant game
- the game has to do with spinning rods and hitting notes when they fall on the rod, timed to music.
- it is built using osu-framework

### features
- read a json file and parse
  - chart name
  - song id (song filename)
  - song name
  - author name
  - list of rods and their respective notes
- contains 3 different "layers":
  - a background layer that does not move with the camera
  - a background layer that does move with the camera
  - the gameplay layer which houses all the rods and notes
  - a HUD layer which houses currently just the song scrub bar
- contains a HUD which has a bar allowing you to scrub forward and backward in a song

### features (new, for siege pepole)
- read custom maps, proper map format
  - in "Resources/Maps", add these files. ensure each file is present. the dynamic image will be the one which has physical world space while stationary moves with the camera. map.json contains a specific format, check the example file for more detail!
  - <img width="203" height="103" alt="image" src="https://github.com/user-attachments/assets/fbf26d1e-7d55-4cc0-a39e-bb6cf63b8a65" />
- play / pausing, bugfixes related to scrollbar being stuck
- added hitsounding
- notes actually spawn, and are relative to its parent rods position
- notes fade in and out when nearby

### disclosures
- i used ai to help write the json parser
