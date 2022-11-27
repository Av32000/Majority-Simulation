# Majority Simulation

It is a simple simulation tool that can predict which side the majority of a crowd will be on according to certain criteria.

There are 3 types of people / 3 populations:

- Undecided : The undecideds do not know which population to join, they are influential
- Classics : Classics are positioned in a population but are also influenceable.
- Millitans : Millitants are sure of their position and millitates to influence others

Each time two people meet, they can convert the other to their side/population.

Idea based on a video of [Fouloscopie](https://www.youtube.com/@Fouloscopie) : [![Preview](https://raw.githubusercontent.com/Av32000/Majority-Simulation/main/src/Videopreview.jpg)](https://www.youtube.com/watch?v=gtXHv95pwyE&t=998s)

## Installation

### Build From source

Clone this repo:

```
git clone https://github.com/Av32000/Majority-Simulation
```

Open it with Unity and build the project.

### Direct Launch

To run the project directly, download [this archive](https://github.com/Av32000/Majority-Simulation/blob/main/src/MajoritySimulation.zip), unnzip it, and run `Majority Simulation.exe`

## Usage

When the project is launched, you will arrive at this screen : ![HomeScreen](https://raw.githubusercontent.com/Av32000/Majority-Simulation/main/src/HomeScreen.png)

### Global Settings

At the top left, you can configure the colour of the floor and 4 other sliders:

1. M/U => The percentage chance of a millitant converting an undecided person
2. M/C => The percentage chance of a millitant converting a classic person
3. C/U => The percentage chance that a classic person will convert an undecided person
4. C/C => The percentage chance that a classic person will convert a classic person

You can also check/uncheck the Keep Majority toggle, which allows you to choose whether the percentage of millitant in a population should be constant (`checked`) or whether it is only effective at the launch of the simulation (`unchecked`).

### Populations Settings

On the right side of the screen, you can change the settings for each population:

1. Name => the name of the population
2. Entity Count => The number of people in this population
3. Color => The colour of the members of this population
4. Speed => The speed of movement of the members of the population
5. Millitant (%) => The percentage of millitant in this population
