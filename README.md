# Lifelong Learning Assessment Notes

## Overview

The assignment is titled "memory game programming test" and the objective is to demonstrate programming skills and an understanding of game development concepts. The assignment needs to be completed ASAP to comply with the requested timeline.
To demonstrate the skills within the requisite time I have down-scoped the project and, where possible, supplied previously created ancillary material to support.

## Polished Experience

Here is one of the memory games I have built in Javascript/Typescript for HTML5 Canvas that show what I would consider a quality memory game to play like. It has:

- 1P and 2P modes
- multiple difficulties
- unlockable card designs
- juicy animations.

It utilizes a preloader, spritesheets, and texture packing. Play "Pick the Pattern":
https://superstem.scholastic.com/content/dam/classroom-magazines/superscience/issues/2018-19/050119/game/index.html

## Rapid Prototype
#### 5-min project walkthrough video here: https://drive.google.com/file/d/1uxjH8edown5_OKe4N_a064FUw7rZlRrK/view?usp=sharing
Our rapid prototype is meant to display core competencies using an ECS engine (Unity) and a typed language (C#). Project scope:

- a visual grid of cards
  - number of cards is player definable
- clicking
  - card reveal
  - card match logic
    - return to normal
    - remove from board
- game completion logic
  - reset game

consider solutions for:

- where/how animations would be played
- where/how sounds would be played

## Experience Visualization/Flow

Player opens game. Textfield for setting the number of card pairs. Play button for starting the game. Reset button for ending and starting a new game with the requested number of card pairs.

Player clicks start (button sound)
Lay out cards (could be animated w/ sound)
Player clicks card.
Card reveals.

Player clicks second card.
Card reveals.

No match.
Cards flip back over.

Match
Remove cards, play celebration
Check cards remaining

If cards remaining, do nothing
If no cards remaining, play celebration

## Development Notes

Start Button and Reset Button are essentially doing the exact same thing. Skipping as non-essential UX.
A card face is essentially identical to its ID. Storing these together in some capacity makes sense.

### Possible Game Tweaks

- If a design appears more than 3 times in a board, allow for chaining

## Estimated Time

4 hours