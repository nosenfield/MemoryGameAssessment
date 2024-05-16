# Lifelong Learning Assessment Notes

## Overview

The assignment is titled "memory game programming test" and the objective is to demonstrate programming skills and an understanding of gave development concepts.
The assignment needs to be completed ASAP to comply with the requested timeline and we do not have the usual amount of time prescribed to complete (a weekend).
To demonstrate the skills within the requisite time I have down-scoped the project and, where possible, supply previously created ancillary material to support.

Minimum requirements to display core competencies:

- a visual grid of cards
- clicking
  - card reveal
  - card match logic
    - return to normal
    - remove from board
- game completion logic
  - reset game

show implementation for

- difficulties (set the number of cards)
- where/how animations would be played
- where/how sounds would be played

## Experience Visualization/Flow

Player opens game. Textfield for setting the number of card pairs. Play button for starting the game. Reset button for ending and starting a new game with the requested number of card pairs.

Player clicks start (button sound)
Lay out cards (could be animated w/ sound)
Player clicks card.
Card reveals - card flips - consider zoom in/out

Player clicks second card.
Card reveals - card flips - consider zoom in/out

No match
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