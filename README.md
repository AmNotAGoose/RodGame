# RodGame Level Editor

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

### disclosures
- i used ai to help write the json parser
