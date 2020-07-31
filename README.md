# Obstacle-Race

# Time invested
Around 4h 30minutes

# Challenges found
- First challenge was time, I think that 5h was a pretty short time to do something that looks polished and finished.
- I thought on making the game in a way that if I had time I could add different type of obstacles ( I only had time for one), to do that I thoughton a way where the player could move from obstacle to obstacle. 
- I wanted to make round cornes, but implementing a bezier curve editor felt like to much for 5h so I used a line renderer to make the rail for the player.
- Also the player movement was quite a challenge, because I wanted to make the player be able to jump, run or do other type of movements like climbing (only did run and jump). Like on the original game. 
- Also I noticed that every obstacle has it's own camera fixed position from where it follows the player, so I made the obstacle has it's own camera position. I had to transitionate from position to position, switching between obstacles.

# Possible improves
It probably has a lot of room of improvement, due to the time, here is my thought right now:

  - How it switches from a type of movement to another, right now I tried to do some composition, where the player runs by default and when switching to another type I deactivate the main movement and activate like the secondary movement. The idea behind it may be good(composition of movements), but the final implementation I think can be improved.
  - Camera transitions are hand made, maybe a good idea to implement them using Unity's cinemachine.
  - Needs more feedback, (dying, winning, completing an obstacle). 
  - Better art, right now are just primitives with plain colors.
# What can be done next
  - As mentinoned on improves, better art and better feedback.
  - I tried to do a LevelConfiguration, where you could add the obstacles of each level, and they would be generated, but it was to ambitious for the time, could be a good idea to work on that to make fast levels, with different type of obstacles and on different orders.
  - More obstacles.
  - Add climbing so you can have climbing obstacles. Also glide or other movements.
  - Change the way to configure the player rail, into a bezier curve editor where you can define the behaviour that the player hast to have on that segment.
  
# Opinion

This test was fun to make but I think the game and code quality would have been better with some extra time.
